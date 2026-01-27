package com.example.bai5_formdangky;

import org.junit.*;

import java.sql.*;
import java.time.LocalDate;

import static org.junit.Assert.*;

public class CustomerRepositoryTest {

    private CustomerRepository repo;

    // dữ liệu seed (phải tồn tại để test trùng)
    private static final String EXIST_CID = "KH0001A";
    private static final String EXIST_EMAIL = "exist@email.com";

    @Before
    public void setUp() throws Exception {
        repo = new CustomerRepository();
        seedIfNotExists();
    }

    @After
    public void tearDown() throws Exception {
        cleanupLike("KH_TEST_%", "test_%@email.com");
    }

    private void seedIfNotExists() throws Exception {
        if (!repo.existsCustomerId(EXIST_CID)) {
            repo.insertCustomer(
                    EXIST_CID,
                    "Seed User",
                    EXIST_EMAIL,
                    "0123456789",
                    "Seed Address",
                    ValidationUtils.hashPasswordSha256("Abc@1234"),
                    LocalDate.now().minusYears(20),
                    "Nam",
                    true
            );
        }
    }

    private void cleanupLike(String cidLike, String emailLike) throws Exception {
        try (Connection c = DriverManager.getConnection(DbConfig.URL, DbConfig.USER, DbConfig.PASSWORD);
             PreparedStatement ps = c.prepareStatement("DELETE FROM Customers WHERE CustomerId LIKE ? OR Email LIKE ?")) {
            ps.setString(1, cidLike);
            ps.setString(2, emailLike);
            ps.executeUpdate();
        }
    }

    @Test // TC10
    public void TC10_customerId_duplicate_inDb() throws Exception {
        assertTrue(repo.existsCustomerId(EXIST_CID));
    }

    @Test // TC21
    public void TC21_email_duplicate_inDb() throws Exception {
        assertTrue(repo.existsEmail(EXIST_EMAIL));
    }

    @Test // TC01/TC02 (insert thành công)
    public void TC01_TC02_insert_success() throws Exception {
        String cid = "KH_TEST_01"; // lưu ý: CID thực tế chỉ chữ+ số, nếu DB ràng buộc -> dùng KHTEST01
        cid = "KHTEST01";
        String email = "test_01@email.com";

        assertFalse(repo.existsCustomerId(cid));
        assertFalse(repo.existsEmail(email));

        repo.insertCustomer(
                cid,
                "Nguyễn Văn A",
                email,
                "0796800155",
                "123 Đường ABC",
                ValidationUtils.hashPasswordSha256("Abc@1234"),
                LocalDate.of(2000, 1, 1),
                "Nam",
                true
        );

        assertTrue(repo.existsCustomerId(cid));
        assertTrue(repo.existsEmail(email));
    }

    @org.junit.Ignore("F-TC05: Expected intentionally wrong (email must be unique)")
    @Test
    public void F_TC05_email_duplicate_shouldFail() throws Exception {
        // kỳ vọng sai: muốn insert được email trùng
        repo.insertCustomer(
                "KHTEST99",
                "Nguyễn Văn A",
                EXIST_EMAIL,
                "0796800155",
                "123 Đường ABC",
                ValidationUtils.hashPasswordSha256("Abc@1234"),
                null,
                null,
                true
        );
    }
}
