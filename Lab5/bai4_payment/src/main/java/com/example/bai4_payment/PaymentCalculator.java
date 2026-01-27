package com.example.bai4_payment;

public class PaymentCalculator {

    public enum PatientType { MALE, FEMALE, CHILD }

    public static int calculate(PatientType type, int age) {
        if (type == null) throw new IllegalArgumentException("Type is required");
        if (age < 0 || age > 145) throw new IllegalArgumentException("Age out of range");

        switch (type) {
            case CHILD:
                if (age <= 17) return 50;
                throw new IllegalArgumentException("Child age must be 0-17");
            case MALE:
                if (age < 18) throw new IllegalArgumentException("Adult age must be >= 18");
                if (age <= 35) return 100;
                if (age <= 50) return 120;
                return 140; // 51-145
            case FEMALE:
                if (age < 18) throw new IllegalArgumentException("Adult age must be >= 18");
                if (age <= 35) return 80;
                if (age <= 50) return 110;
                return 140; // 51-145
            default:
                throw new IllegalArgumentException("Unsupported type");
        }
    }
}
