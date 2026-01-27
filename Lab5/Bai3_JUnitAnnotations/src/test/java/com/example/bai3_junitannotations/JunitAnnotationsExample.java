package com.example.bai3_junitannotations;

import org.junit.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.Assert.*;

public class JunitAnnotationsExample {

    private static List<String> defaultData;   // dữ liệu dùng chung (shared)
    private ArrayList<String> list;            // fixture cho từng test

    @BeforeClass
    public static void beforeAll() {
        defaultData = Arrays.asList("java", "junit", "testing");
        System.out.println("Using @BeforeClass - executed once before all test cases");
    }

    @AfterClass
    public static void afterAll() {
        defaultData = null;
        System.out.println("Using @AfterClass - executed once after all test cases");
    }

    @Before
    public void setUp() {
        list = new ArrayList<>(defaultData);
        System.out.println("Using @Before - executed before each test case");
    }

    @After
    public void tearDown() {
        list.clear();
        System.out.println("Using @After - executed after each test case");
    }

    @Test
    public void addItem_listSizeIncreases_andContainsItem() {
        int oldSize = list.size();
        list.add("mockito");
        assertEquals(oldSize + 1, list.size());
        assertTrue(list.contains("mockito"));
        assertFalse(list.isEmpty());
    }

    @Test
    public void removeExistingItem_itemRemoved_andSizeDecreases() {
        int oldSize = list.size();
        boolean removed = list.remove("junit");
        assertTrue(removed);
        assertEquals(oldSize - 1, list.size());
        assertFalse(list.contains("junit"));
    }

    @Test
    public void removeNonExistingItem_returnsFalse_andSizeUnchanged() {
        int oldSize = list.size();
        boolean removed = list.remove("not-exist");
        assertFalse(removed);
        assertEquals(oldSize, list.size());
    }

    @Test(expected = IndexOutOfBoundsException.class)
    public void getIndexOutOfBounds_throwsException() {
        list.get(999);
    }

    @Test(timeout = 50)
    public void searchOperation_shouldFinishQuickly() {
        for (int i = 0; i < 10000; i++) {
            list.contains("junit");
        }
    }

    @Ignore("Minh hoạ @Ignore - test tạm bỏ qua")
    @Test
    public void ignoredExample_futureFeature() {
        // cố tình sai để thấy ignore hoạt động
        assertTrue(list.contains("JUnit"));
    }
}
