package com.example.bai2_test_suite;


public class JUnitMessage {

    private String message;

    public JUnitMessage(String message) {
        this.message = message;
    }

    public void printMessage() {
        System.out.println(message);
        int a = 1 / 0; // cố ý gây ArithmeticException
    }

    public String printHiMessage() {
        return "Hi!" + message;
    }
}
