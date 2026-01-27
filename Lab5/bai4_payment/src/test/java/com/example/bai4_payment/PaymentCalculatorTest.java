package com.example.bai4_payment;

import org.junit.Test;
import static org.junit.Assert.*;
import static com.example.bai4_payment.PaymentCalculator.PatientType.*;

public class PaymentCalculatorTest {

    // -------- Valid cases (BVA + EP) --------
    @Test public void child_age0_payment50() { assertEquals(50, PaymentCalculator.calculate(CHILD, 0)); }
    @Test public void child_age17_payment50() { assertEquals(50, PaymentCalculator.calculate(CHILD, 17)); }
    @Test public void male_age18_payment100() { assertEquals(100, PaymentCalculator.calculate(MALE, 18)); }
    @Test public void male_age35_payment100() { assertEquals(100, PaymentCalculator.calculate(MALE, 35)); }
    @Test public void male_age36_payment120() { assertEquals(120, PaymentCalculator.calculate(MALE, 36)); }
    @Test public void male_age50_payment120() { assertEquals(120, PaymentCalculator.calculate(MALE, 50)); }
    @Test public void male_age51_payment140() { assertEquals(140, PaymentCalculator.calculate(MALE, 51)); }
    @Test public void male_age145_payment140() { assertEquals(140, PaymentCalculator.calculate(MALE, 145)); }

    @Test public void female_age18_payment80() { assertEquals(80, PaymentCalculator.calculate(FEMALE, 18)); }
    @Test public void female_age35_payment80() { assertEquals(80, PaymentCalculator.calculate(FEMALE, 35)); }
    @Test public void female_age36_payment110() { assertEquals(110, PaymentCalculator.calculate(FEMALE, 36)); }
    @Test public void female_age50_payment110() { assertEquals(110, PaymentCalculator.calculate(FEMALE, 50)); }
    @Test public void female_age51_payment140() { assertEquals(140, PaymentCalculator.calculate(FEMALE, 51)); }
    @Test public void female_age145_payment140() { assertEquals(140, PaymentCalculator.calculate(FEMALE, 145)); }

    // -------- Invalid cases (robust + mismatch) --------
    @Test(expected = IllegalArgumentException.class)
    public void age_negative_throws() { PaymentCalculator.calculate(CHILD, -1); }

    @Test(expected = IllegalArgumentException.class)
    public void age_over145_throws() { PaymentCalculator.calculate(MALE, 146); }

    @Test(expected = IllegalArgumentException.class)
    public void child_age18_throws() { PaymentCalculator.calculate(CHILD, 18); }

    @Test(expected = IllegalArgumentException.class)
    public void male_age17_throws() { PaymentCalculator.calculate(MALE, 17); }

    @Test(expected = IllegalArgumentException.class)
    public void female_age0_throws() { PaymentCalculator.calculate(FEMALE, 0); }

    @Test(expected = IllegalArgumentException.class)
    public void nullType_throws() { PaymentCalculator.calculate(null, 20); }
}
