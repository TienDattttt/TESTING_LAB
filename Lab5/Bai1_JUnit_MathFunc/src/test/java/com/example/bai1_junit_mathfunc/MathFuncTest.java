package com.example.bai1_junit_mathfunc;

import org.junit.*;
import static org.junit.Assert.*;

public class MathFuncTest {

    private MathFunc math;

    @Before
    public void init() {
        math = new MathFunc();   // test fixture: tạo mới trước mỗi test
    }

    @After
    public void tearDown() {
        math = null;             // dọn sau mỗi test
    }

    @Test
    public void calls_initiallyZero() {
        assertEquals(0, math.getCalls());
    }

    @Test
    public void factorial_basicCases() {
        assertTrue(math.factorial(0) == 1);
        assertTrue(math.factorial(1) == 1);
        assertTrue(math.factorial(5) == 120);
    }

    @Test(expected = IllegalArgumentException.class)
    public void factorial_negative_throwsException() {
        math.factorial(-1);
    }

    @Test
    public void plus_basic() {
        assertEquals(5, math.plus(2, 3));
        assertEquals(1, math.plus(-2, 3));
    }

    @Test
    public void calls_increaseCorrectly() {
        assertEquals(0, math.getCalls());

        math.factorial(1);
        assertEquals(1, math.getCalls());

        math.plus(1, 2);
        assertEquals(2, math.getCalls());
    }

    @Ignore
    @Test
    public void todo_ignoreExample() {
        // Ví dụ test bị bỏ qua (theo hướng dẫn đề)
        assertTrue(math.plus(1, 1) == 3);
    }
}

