package com.example.bai5_formdangky;

import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.time.LocalDate;
import java.time.ZoneId;
import java.util.Date;

public class CustomerRegistrationForm extends JFrame {

    private final JTextField txtCustomerId = new JTextField(22);
    private final JTextField txtFullName   = new JTextField(22);
    private final JTextField txtEmail      = new JTextField(22);
    private final JTextField txtPhone      = new JTextField(22);
    private final JTextArea  txtAddress    = new JTextArea(3, 22);

    private final JPasswordField txtPassword = new JPasswordField(22);
    private final JPasswordField txtConfirm  = new JPasswordField(22);

    private final JCheckBox chkUseBirthDate = new JCheckBox("Nhập ngày sinh");
    private final JSpinner spBirthDate = new JSpinner(new SpinnerDateModel());
    private final JLabel lblBirthHint = new JLabel("mm/dd/yyyy");

    private final JRadioButton rMale   = new JRadioButton("Nam");
    private final JRadioButton rFemale = new JRadioButton("Nữ");
    private final JRadioButton rOther  = new JRadioButton("Khác");

    private final JCheckBox chkTos = new JCheckBox("Tôi đồng ý với các điều khoản dịch vụ *");

    private final JButton btnRegister = new JButton("Đăng ký");
    private final JButton btnReset    = new JButton("Nhập lại");

    // label lỗi theo từng field
    private final JLabel errCustomerId = errLabel();
    private final JLabel errFullName   = errLabel();
    private final JLabel errEmail      = errLabel();
    private final JLabel errPhone      = errLabel();
    private final JLabel errAddress    = errLabel();
    private final JLabel errPassword   = errLabel();
    private final JLabel errConfirm    = errLabel();
    private final JLabel errBirthDate  = errLabel();
    private final JLabel errTos        = errLabel();

    private final CustomerRepository repo = new CustomerRepository();

    public CustomerRegistrationForm() {
        super("ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setSize(760, 520);
        setLocationRelativeTo(null);

        // UI setup
        txtAddress.setLineWrap(true);
        txtAddress.setWrapStyleWord(true);

        spBirthDate.setEditor(new JSpinner.DateEditor(spBirthDate, "MM/dd/yyyy"));
        spBirthDate.setEnabled(false);
        lblBirthHint.setForeground(Color.GRAY);

        ButtonGroup genderGroup = new ButtonGroup();
        genderGroup.add(rMale);
        genderGroup.add(rFemale);
        genderGroup.add(rOther);

        JPanel root = new JPanel(new BorderLayout());
        root.setBorder(new EmptyBorder(16, 16, 16, 16));
        root.add(buildTitle(), BorderLayout.NORTH);
        root.add(buildForm(), BorderLayout.CENTER);
        root.add(buildButtons(), BorderLayout.SOUTH);
        setContentPane(root);

        // events
        chkUseBirthDate.addActionListener(e -> spBirthDate.setEnabled(chkUseBirthDate.isSelected()));
        btnReset.addActionListener(e -> resetForm());
        btnRegister.addActionListener(e -> onRegister());
    }

    private JComponent buildTitle() {
        JLabel title = new JLabel("ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG", SwingConstants.CENTER);
        title.setFont(title.getFont().deriveFont(Font.BOLD, 18f));
        JPanel p = new JPanel(new BorderLayout());
        p.add(title, BorderLayout.CENTER);
        p.setBorder(new EmptyBorder(0, 0, 12, 0));
        return p;
    }

    private JComponent buildForm() {
        JPanel panel = new JPanel(new GridBagLayout());
        GridBagConstraints g = new GridBagConstraints();
        g.insets = new Insets(6, 6, 6, 6);
        g.anchor = GridBagConstraints.WEST;
        g.fill = GridBagConstraints.HORIZONTAL;
        g.weightx = 1;

        int row = 0;

        row = addField(panel, g, row, "Mã Khách Hàng *", txtCustomerId, errCustomerId, "6-10 ký tự, chỉ chữ và số");
        row = addField(panel, g, row, "Họ và Tên *", txtFullName, errFullName, "Nhập họ tên đầy đủ");
        row = addField(panel, g, row, "Email *", txtEmail, errEmail, "vd: nguyenvana@email.com");
        row = addField(panel, g, row, "Số điện thoại *", txtPhone, errPhone, "Bắt đầu bằng số 0, 10-12 số");

        // Address (textarea)
        g.gridy = row; g.gridx = 0; g.weightx = 0; g.fill = GridBagConstraints.NONE;
        panel.add(new JLabel("Địa chỉ *"), g);
        g.gridx = 1; g.weightx = 1; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(new JScrollPane(txtAddress), g);
        g.gridx = 2; g.weightx = 0; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(errAddress, g);
        row++;

        row = addField(panel, g, row, "Mật khẩu *", txtPassword, errPassword, "Ít nhất 8 ký tự");
        row = addField(panel, g, row, "Xác nhận Mật khẩu *", txtConfirm, errConfirm, "Nhập lại mật khẩu");

        // Birth date (optional)
        g.gridy = row; g.gridx = 0; g.weightx = 0; g.fill = GridBagConstraints.NONE;
        panel.add(new JLabel("Ngày sinh"), g);

        JPanel birthWrap = new JPanel(new FlowLayout(FlowLayout.LEFT, 8, 0));
        birthWrap.add(chkUseBirthDate);
        birthWrap.add(spBirthDate);
        birthWrap.add(lblBirthHint);

        g.gridx = 1; g.weightx = 1; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(birthWrap, g);
        g.gridx = 2; g.weightx = 0;
        panel.add(errBirthDate, g);
        row++;

        // Gender (optional)
        g.gridy = row; g.gridx = 0; g.weightx = 0; g.fill = GridBagConstraints.NONE;
        panel.add(new JLabel("Giới tính"), g);

        JPanel genderWrap = new JPanel(new FlowLayout(FlowLayout.LEFT, 12, 0));
        genderWrap.add(rMale);
        genderWrap.add(rFemale);
        genderWrap.add(rOther);

        g.gridx = 1; g.weightx = 1; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(genderWrap, g);
        g.gridx = 2; g.weightx = 0;
        panel.add(new JLabel(""), g);
        row++;

        // TOS
        g.gridy = row; g.gridx = 1; g.weightx = 1;
        panel.add(chkTos, g);
        g.gridx = 2; g.weightx = 0;
        panel.add(errTos, g);

        return panel;
    }

    private JComponent buildButtons() {
        JPanel p = new JPanel(new FlowLayout(FlowLayout.CENTER, 12, 12));
        btnRegister.setPreferredSize(new Dimension(120, 36));
        btnReset.setPreferredSize(new Dimension(120, 36));
        p.add(btnRegister);
        p.add(btnReset);
        return p;
    }

    private int addField(JPanel panel, GridBagConstraints g, int row,
                         String label, JComponent field, JLabel err, String hint) {
        g.gridy = row; g.gridx = 0; g.weightx = 0; g.fill = GridBagConstraints.NONE;
        panel.add(new JLabel(label), g);

        JPanel wrap = new JPanel(new BorderLayout(8, 0));
        wrap.add(field, BorderLayout.CENTER);
        JLabel hintLbl = new JLabel(hint);
        hintLbl.setForeground(Color.GRAY);
        hintLbl.setFont(hintLbl.getFont().deriveFont(12f));
        wrap.add(hintLbl, BorderLayout.SOUTH);

        g.gridx = 1; g.weightx = 1; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(wrap, g);

        g.gridx = 2; g.weightx = 0; g.fill = GridBagConstraints.HORIZONTAL;
        panel.add(err, g);

        return row + 1;
    }

    private JLabel errLabel() {
        JLabel l = new JLabel(" ");
        l.setForeground(new Color(180, 0, 0));
        l.setFont(l.getFont().deriveFont(12f));
        return l;
    }

    private void clearErrors() {
        errCustomerId.setText(" ");
        errFullName.setText(" ");
        errEmail.setText(" ");
        errPhone.setText(" ");
        errAddress.setText(" ");
        errPassword.setText(" ");
        errConfirm.setText(" ");
        errBirthDate.setText(" ");
        errTos.setText(" ");
    }

    private void resetForm() {
        txtCustomerId.setText("");
        txtFullName.setText("");
        txtEmail.setText("");
        txtPhone.setText("");
        txtAddress.setText("");
        txtPassword.setText("");
        txtConfirm.setText("");

        chkUseBirthDate.setSelected(false);
        spBirthDate.setEnabled(false);
        spBirthDate.setValue(new Date());

        rMale.setSelected(false);
        rFemale.setSelected(false);
        rOther.setSelected(false);

        chkTos.setSelected(false);

        clearErrors();
    }

    private void onRegister() {
        clearErrors();

        String customerId = txtCustomerId.getText().trim();
        String fullName = txtFullName.getText().trim();
        String email = txtEmail.getText().trim();
        String phone = txtPhone.getText().trim();
        String address = txtAddress.getText().trim();
        String password = new String(txtPassword.getPassword());
        String confirm  = new String(txtConfirm.getPassword());

        boolean ok = true;

        String e;

        e = ValidationUtils.validateCustomerId(customerId);
        if (e != null) { errCustomerId.setText(e); ok = false; }

        e = ValidationUtils.validateFullName(fullName);
        if (e != null) { errFullName.setText(e); ok = false; }

        e = ValidationUtils.validateEmail(email);
        if (e != null) { errEmail.setText(e); ok = false; }

        e = ValidationUtils.validatePhone(phone);
        if (e != null) { errPhone.setText(e); ok = false; }

        e = ValidationUtils.validateAddress(address);
        if (e != null) { errAddress.setText(e); ok = false; }

        e = ValidationUtils.validatePassword(password);
        if (e != null) { errPassword.setText(e); ok = false; }

        e = ValidationUtils.validateConfirmPassword(password, confirm);
        if (e != null) { errConfirm.setText(e); ok = false; }

        LocalDate birthDateOrNull = null;
        if (chkUseBirthDate.isSelected()) {
            Date d = (Date) spBirthDate.getValue();
            birthDateOrNull = d.toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
        }
        e = ValidationUtils.validateBirthDate(birthDateOrNull);
        if (e != null) { errBirthDate.setText(e); ok = false; }

        if (!chkTos.isSelected()) {
            errTos.setText("Bắt buộc.");
            ok = false;
        }

        // Nếu validate local fail → dừng
        if (!ok) return;

        // Gender optional
        String gender = null;
        if (rMale.isSelected()) gender = "Nam";
        else if (rFemale.isSelected()) gender = "Nữ";
        else if (rOther.isSelected()) gender = "Khác";

        // Validate uniqueness + insert DB
        try {
            if (repo.existsCustomerId(customerId)) {
                errCustomerId.setText("Mã khách hàng đã tồn tại (không được trùng).");
                return;
            }
            if (repo.existsEmail(email)) {
                errEmail.setText("Email đã tồn tại (không được trùng).");
                return;
            }

            String passHash = ValidationUtils.hashPasswordSha256(password);

            repo.insertCustomer(
                    customerId, fullName, email, phone, address,
                    passHash, birthDateOrNull, gender, true
            );

            JOptionPane.showMessageDialog(this,
                    "Đăng ký tài khoản thành công!",
                    "Success", JOptionPane.INFORMATION_MESSAGE);
            resetForm();

        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this,
                    "Lỗi kết nối/ghi CSDL: " + ex.getMessage(),
                    "Database Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new CustomerRegistrationForm().setVisible(true));
    }
}