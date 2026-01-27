package com.example.bai5_formdangky;

import java.sql.*;
import java.time.LocalDate;

public class CustomerRepository {

    private Connection open() throws SQLException {
        return DriverManager.getConnection(DbConfig.URL, DbConfig.USER, DbConfig.PASSWORD);
    }

    public boolean existsCustomerId(String customerId) throws SQLException {
        String sql = "SELECT 1 FROM Customers WHERE CustomerId = ?";
        try (Connection c = open();
             PreparedStatement ps = c.prepareStatement(sql)) {
            ps.setString(1, customerId);
            try (ResultSet rs = ps.executeQuery()) {
                return rs.next();
            }
        }
    }

    public boolean existsEmail(String email) throws SQLException {
        String sql = "SELECT 1 FROM Customers WHERE Email = ?";
        try (Connection c = open();
             PreparedStatement ps = c.prepareStatement(sql)) {
            ps.setString(1, email);
            try (ResultSet rs = ps.executeQuery()) {
                return rs.next();
            }
        }
    }

    public void insertCustomer(
            String customerId,
            String fullName,
            String email,
            String phone,
            String address,
            String passwordHash,
            LocalDate birthDateOrNull,
            String genderOrNull,
            boolean acceptedTos
    ) throws SQLException {

        String sql = """
            INSERT INTO Customers(CustomerId, FullName, Email, Phone, Address, PasswordHash, BirthDate, Gender, AcceptedTos)
            VALUES(?,?,?,?,?,?,?,?,?)
        """;

        try (Connection c = open();
             PreparedStatement ps = c.prepareStatement(sql)) {

            ps.setString(1, customerId);
            ps.setString(2, fullName);
            ps.setString(3, email);
            ps.setString(4, phone);
            ps.setString(5, address);
            ps.setString(6, passwordHash);

            if (birthDateOrNull == null) ps.setNull(7, Types.DATE);
            else ps.setDate(7, Date.valueOf(birthDateOrNull));

            if (genderOrNull == null || genderOrNull.isBlank()) ps.setNull(8, Types.NVARCHAR);
            else ps.setString(8, genderOrNull);

            ps.setBoolean(9, acceptedTos);

            ps.executeUpdate();
        }
    }
}
