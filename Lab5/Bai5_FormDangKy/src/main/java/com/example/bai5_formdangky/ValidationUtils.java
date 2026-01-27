package com.example.bai5_formdangky;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.time.LocalDate;
import java.time.Period;
import java.util.regex.Pattern;

public class ValidationUtils {

    private static final Pattern CUSTOMER_ID = Pattern.compile("^[A-Za-z0-9]{6,10}$");
    private static final Pattern EMAIL = Pattern.compile("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$");
    private static final Pattern PHONE = Pattern.compile("^0\\d{9,11}$"); // bắt đầu 0, tổng 10-12 số

    public static String validateCustomerId(String id) {
        if (isBlank(id)) return "Mã khách hàng là bắt buộc.";
        if (!CUSTOMER_ID.matcher(id).matches())
            return "Mã KH phải 6-10 ký tự, chỉ gồm chữ và số (a-z, A-Z, 0-9).";
        return null;
    }

    public static String validateFullName(String name) {
        if (isBlank(name)) return "Họ và tên là bắt buộc.";
        String trimmed = name.trim();
        int len = trimmed.length();
        if (len < 5 || len > 50) return "Họ và tên phải từ 5 đến 50 ký tự.";
        // cho phép tiếng Việt có dấu + khoảng trắng → không chặn regex gắt, chỉ kiểm tra độ dài
        return null;
    }

    public static String validateEmail(String email) {
        if (isBlank(email)) return "Email là bắt buộc.";
        if (!EMAIL.matcher(email.trim()).matches()) return "Email không đúng định dạng (vd: abc@email.com).";
        return null;
    }

    public static String validatePhone(String phone) {
        if (isBlank(phone)) return "Số điện thoại là bắt buộc.";
        if (!PHONE.matcher(phone.trim()).matches())
            return "SĐT phải bắt đầu bằng 0, chỉ gồm số và dài 10-12 ký tự.";
        return null;
    }

    public static String validateAddress(String address) {
        if (isBlank(address)) return "Địa chỉ là bắt buộc.";
        if (address.trim().length() > 255) return "Địa chỉ tối đa 255 ký tự.";
        return null;
    }

    public static String validatePassword(String pass) {
        if (isBlank(pass)) return "Mật khẩu là bắt buộc.";
        if (pass.length() < 8) return "Mật khẩu tối thiểu 8 ký tự.";
        return null;
    }

    public static String validateConfirmPassword(String pass, String confirm) {
        if (isBlank(confirm)) return "Xác nhận mật khẩu là bắt buộc.";
        if (!confirm.equals(pass)) return "Xác nhận mật khẩu không khớp.";
        return null;
    }

    public static String validateBirthDate(LocalDate birthDateOrNull) {
        if (birthDateOrNull == null) return null; // không bắt buộc
        LocalDate today = LocalDate.now();
        if (birthDateOrNull.isAfter(today)) return "Ngày sinh không hợp lệ (ở tương lai).";
        int age = Period.between(birthDateOrNull, today).getYears();
        if (age < 18) return "Người dùng phải đủ 18 tuổi (nếu nhập ngày sinh).";
        return null;
    }

    public static String hashPasswordSha256(String raw) {
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            byte[] out = md.digest(raw.getBytes(StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            for (byte b : out) sb.append(String.format("%02x", b));
            return sb.toString();
        } catch (Exception e) {
            // fallback (không nên xảy ra)
            return raw;
        }
    }

    private static boolean isBlank(String s) {
        return s == null || s.trim().isEmpty();
    }
}
