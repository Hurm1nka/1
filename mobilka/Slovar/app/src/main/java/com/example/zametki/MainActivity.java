package com.example.zametki;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.EditText;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private EditText txtKey;
    private EditText txtValue;
    private DB db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtKey = findViewById(R.id.txt_key);
        txtValue = findViewById(R.id.txt_value);
        db = new DB(this);
    }

    public void onInsertClick(View view) {
        String key = txtKey.getText().toString().trim();
        String value = txtValue.getText().toString();

        if (TextUtils.isEmpty(key)) {
            showErrorDialog(R.string.error_title, R.string.error_empty_key);
            return;
        }
        if (db.keyExists(key)) {
            showErrorDialog(R.string.error_title, R.string.error_duplicate_key, key);
            return;
        }

        db.insert(key, value);
    }

    public void onSelectClick(View view) {
        String key = txtKey.getText().toString().trim();

        if (TextUtils.isEmpty(key)) {
            showErrorDialog(R.string.error_title, R.string.error_empty_key);
            return;
        }

        String value = db.select(key);
        if (value == null) {
            showErrorDialog(R.string.error_title, R.string.error_key_not_found, key);
            return;
        }

        txtValue.setText(value);
    }

    public void onUpdateClick(View view) {
        String key = txtKey.getText().toString().trim();
        String value = txtValue.getText().toString();

        if (TextUtils.isEmpty(key)) {
            showErrorDialog(R.string.error_title, R.string.error_empty_key);
            return;
        }
        if (!db.keyExists(key)) {
            showErrorDialog(R.string.error_title, R.string.error_key_not_found, key);
            return;
        }

        db.update(key, value);
    }

    public void onDeleteClick(View view) {
        String key = txtKey.getText().toString().trim();

        if (TextUtils.isEmpty(key)) {
            showErrorDialog(R.string.error_title, R.string.error_empty_key);
            return;
        }
        if (!db.keyExists(key)) {
            showErrorDialog(R.string.error_title, R.string.error_key_not_found, key);
            return;
        }

        new AlertDialog.Builder(this)
                .setTitle(R.string.delete_title)
                .setIcon(R.drawable.dialog_icon)
                .setMessage(getString(R.string.delete_message, key))
                .setPositiveButton(R.string.dialog_ok, (dialog, which) -> {
                    db.delete(key);
                    txtValue.setText("");
                })
                .setNegativeButton(R.string.dialog_cancel, null)
                .show();
    }

    private void showErrorDialog(int titleResId, int messageResId) {
        new AlertDialog.Builder(this)
                .setTitle(titleResId)
                .setIcon(R.drawable.dialog_icon)
                .setMessage(messageResId)
                .setPositiveButton(R.string.dialog_ok, null)
                .show();
    }

    private void showErrorDialog(int titleResId, int messageResId, String key) {
        new AlertDialog.Builder(this)
                .setTitle(titleResId)
                .setIcon(R.drawable.dialog_icon)
                .setMessage(getString(messageResId, key))
                .setPositiveButton(R.string.dialog_ok, null)
                .show();
    }
}
