package com.example.bai4_payment;

import javax.swing.*;
import java.awt.*;

import static com.example.bai4_payment.PaymentCalculator.PatientType;

public class PaymentForm extends JFrame {

    private final JRadioButton rMale = new JRadioButton("Male");
    private final JRadioButton rFemale = new JRadioButton("Female");
    private final JRadioButton rChild = new JRadioButton("Child (0 - 17 years)");

    private final JTextField txtAge = new JTextField(10);
    private final JTextField txtPayment = new JTextField(10);
    private final JButton btnCalculate = new JButton("Calculate");
    private final JLabel lblStatus = new JLabel(" ");

    public PaymentForm() {
        super("Calculate the Payment for the Patient");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(520, 220);
        setLocationRelativeTo(null);

        txtPayment.setEditable(false);

        // Group radio buttons (để tránh chọn nhiều)
        ButtonGroup group = new ButtonGroup();
        group.add(rMale);
        group.add(rFemale);
        group.add(rChild);

        JPanel top = new JPanel(new FlowLayout(FlowLayout.LEFT));
        top.add(rMale); top.add(rFemale); top.add(rChild);

        JPanel mid = new JPanel(new FlowLayout(FlowLayout.LEFT));
        mid.add(new JLabel("Age (Years)"));
        mid.add(txtAge);
        mid.add(btnCalculate);

        JPanel bottom = new JPanel(new FlowLayout(FlowLayout.LEFT));
        bottom.add(new JLabel("Payment is"));
        bottom.add(txtPayment);
        bottom.add(new JLabel("euro €"));

        lblStatus.setForeground(Color.RED);

        JPanel root = new JPanel();
        root.setLayout(new BoxLayout(root, BoxLayout.Y_AXIS));
        root.add(top);
        root.add(mid);
        root.add(bottom);
        root.add(lblStatus);

        setContentPane(root);

        btnCalculate.addActionListener(e -> onCalculate());
    }

    private void onCalculate() {
        lblStatus.setText(" ");
        txtPayment.setText("");

        PatientType type = getSelectedType();
        if (type == null) {
            lblStatus.setText("Please select patient type.");
            return;
        }

        String raw = txtAge.getText().trim();
        if (raw.isEmpty()) {
            lblStatus.setText("Age is required.");
            return;
        }

        int age;
        try {
            age = Integer.parseInt(raw);
        } catch (NumberFormatException ex) {
            lblStatus.setText("Age must be an integer.");
            return;
        }

        try {
            int payment = PaymentCalculator.calculate(type, age);
            txtPayment.setText(String.valueOf(payment));
        } catch (IllegalArgumentException ex) {
            lblStatus.setText(ex.getMessage());
        }
    }

    private PatientType getSelectedType() {
        if (rMale.isSelected()) return PatientType.MALE;
        if (rFemale.isSelected()) return PatientType.FEMALE;
        if (rChild.isSelected()) return PatientType.CHILD;
        return null;
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new PaymentForm().setVisible(true));
    }
}
