package com.example.bai2_test_suite;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;

@RunWith(Suite.class)
@Suite.SuiteClasses({
        SuiteTest1.class,
        SuiteTest2.class
})
public class JunitTest {
    // Class này không chứa code test
    // Chỉ dùng để gom và chạy các test class
}

