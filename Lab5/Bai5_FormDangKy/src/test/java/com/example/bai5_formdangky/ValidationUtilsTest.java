package com.example.bai5_formdangky;

import org.junit.Test;

import java.time.LocalDate;

import static org.junit.Assert.*;

public class ValidationUtilsTest {

    // ========== CustomerId (TC04..TC09) ==========
    @Test // TC04
    public void TC04_customerId_required() {
        assertEquals("Mã khách hàng là bắt buộc.", ValidationUtils.validateCustomerId(""));
    }

    @Test // TC05
    public void TC05_customerId_tooShort_5chars() {
        assertNotNull(ValidationUtils.validateCustomerId("KH123")); // 5
    }

    @Test // TC06
    public void TC06_customerId_len6_valid() {
        assertNull(ValidationUtils.validateCustomerId("KH1234"));
    }

    @Test // TC07
    public void TC07_customerId_len10_valid() {
        assertNull(ValidationUtils.validateCustomerId("KH1234ABCD"));
    }

    @Test // TC08
    public void TC08_customerId_len11_invalid() {
        assertNotNull(ValidationUtils.validateCustomerId("KH1234ABCDE")); // 11
    }

    @Test // TC09
    public void TC09_customerId_specialChar_invalid() {
        assertNotNull(ValidationUtils.validateCustomerId("KH12@34"));
    }

    // F-TC01 (Expected sai) -> Ignore để minh hoạ
    @org.junit.Ignore("F-TC01: Expected intentionally wrong (spec forbids _)")
    @Test
    public void F_TC01_customerId_withUnderscore_shouldFail() {
        // cố tình kỳ vọng sai: muốn hợp lệ
        assertNull(ValidationUtils.validateCustomerId("KH_1234"));
    }

    // ========== FullName (TC11..TC16) ==========
    @Test // TC11
    public void TC11_fullName_required() {
        assertEquals("Họ và tên là bắt buộc.", ValidationUtils.validateFullName(""));
    }

    @Test // TC12
    public void TC12_fullName_tooShort_4chars() {
        assertNotNull(ValidationUtils.validateFullName("An A")); // 4
    }

    @Test // TC13
    public void TC13_fullName_len5_valid() {
        assertNull(ValidationUtils.validateFullName("A B C")); // 5
    }

    @Test // TC14
    public void TC14_fullName_len50_valid() {
        String name50 = "A".repeat(50);
        assertNull(ValidationUtils.validateFullName(name50));
    }

    @Test // TC15
    public void TC15_fullName_len51_invalid() {
        String name51 = "A".repeat(51);
        assertNotNull(ValidationUtils.validateFullName(name51));
    }

    @Test // TC16
    public void TC16_fullName_vietnamese_valid() {
        assertNull(ValidationUtils.validateFullName("Trần Thị Ánh Ngọc"));
    }

    // ========== Email (TC17..TC20) ==========
    @Test // TC17
    public void TC17_email_required() {
        assertEquals("Email là bắt buộc.", ValidationUtils.validateEmail(""));
    }

    @Test // TC18
    public void TC18_email_missingAt_invalid() {
        assertNotNull(ValidationUtils.validateEmail("abcgmail.com"));
    }

    @Test // TC19
    public void TC19_email_missingDomain_invalid() {
        assertNotNull(ValidationUtils.validateEmail("abc@"));
    }

    @Test // TC20
    public void TC20_email_valid() {
        assertNull(ValidationUtils.validateEmail("new@email.com"));
    }

    // ========== Phone (TC22..TC28) ==========
    @Test // TC22
    public void TC22_phone_required() {
        assertEquals("Số điện thoại là bắt buộc.", ValidationUtils.validatePhone(""));
    }

    @Test // TC23
    public void TC23_phone_containsLetter_invalid() {
        assertNotNull(ValidationUtils.validatePhone("07968A0155"));
    }

    @Test // TC24
    public void TC24_phone_notStartWith0_invalid() {
        assertNotNull(ValidationUtils.validatePhone("1796800155"));
    }

    @Test // TC25
    public void TC25_phone_len9_invalid() {
        assertNotNull(ValidationUtils.validatePhone("012345678")); // 9
    }

    @Test // TC26
    public void TC26_phone_len10_valid() {
        assertNull(ValidationUtils.validatePhone("0123456789"));
    }

    @Test // TC27
    public void TC27_phone_len12_valid() {
        assertNull(ValidationUtils.validatePhone("012345678901"));
    }

    @Test // TC28
    public void TC28_phone_len13_invalid() {
        assertNotNull(ValidationUtils.validatePhone("0123456789012"));
    }

    // ========== Address (TC29..TC31) ==========
    @Test // TC29
    public void TC29_address_required() {
        assertEquals("Địa chỉ là bắt buộc.", ValidationUtils.validateAddress(""));
    }

    @Test // TC30
    public void TC30_address_len255_valid() {
        String s = "A".repeat(255);
        assertNull(ValidationUtils.validateAddress(s));
    }

    @Test // TC31
    public void TC31_address_len256_invalid() {
        String s = "A".repeat(256);
        assertNotNull(ValidationUtils.validateAddress(s));
    }

    // ========== Password & Confirm (TC32..TC36) ==========
    @Test // TC32
    public void TC32_password_required() {
        assertEquals("Mật khẩu là bắt buộc.", ValidationUtils.validatePassword(""));
        assertEquals("Xác nhận mật khẩu là bắt buộc.", ValidationUtils.validateConfirmPassword("", ""));
    }

    @Test // TC33
    public void TC33_password_len7_invalid() {
        assertNotNull(ValidationUtils.validatePassword("Abc1234")); // 7
    }

    @Test // TC34
    public void TC34_password_len8_valid() {
        assertNull(ValidationUtils.validatePassword("Abc@1234")); // 8
    }

    @Test // TC35
    public void TC35_confirm_required() {
        assertEquals("Xác nhận mật khẩu là bắt buộc.",
                ValidationUtils.validateConfirmPassword("Abc@1234", ""));
    }

    @Test // TC36
    public void TC36_confirm_notMatch_invalid() {
        assertNotNull(ValidationUtils.validateConfirmPassword("Abc@1234", "Abc@1235"));
    }

    @org.junit.Ignore("F-TC02: Expected intentionally wrong (password min is 8)")
    @Test
    public void F_TC02_password_len6_shouldFail() {
        // cố tình kỳ vọng sai: muốn pass
        assertNull(ValidationUtils.validatePassword("Abc123"));
    }

    // ========== DOB (tuổi >= 18) ==========
    @Test // tương ứng nhóm DOB (TC38..TC40)
    public void TC38_dob_age17_invalid() {
        LocalDate dob17 = LocalDate.now().minusYears(17);
        assertNotNull(ValidationUtils.validateBirthDate(dob17));
    }

    @Test
    public void TC39_dob_age18_valid() {
        LocalDate dob18 = LocalDate.now().minusYears(18);
        assertNull(ValidationUtils.validateBirthDate(dob18));
    }

    @Test
    public void TC40_dob_future_invalid() {
        LocalDate future = LocalDate.now().plusDays(1);
        assertNotNull(ValidationUtils.validateBirthDate(future));
    }
}
