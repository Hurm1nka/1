package com.example.twoactivites

import android.app.Activity
import android.app.AlertDialog
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    private lateinit var txtData: EditText

    private val launcher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            val returned = result.data?.getStringExtra("result") ?: ""
            txtData.setText(returned)
            Toast.makeText(this, returned, Toast.LENGTH_SHORT).show()
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        txtData = findViewById(R.id.txtData)

        findViewById<Button>(R.id.btnOpen).setOnClickListener {
            val intent = Intent(this, SecondActivity::class.java)
            intent.putExtra("data", txtData.text.toString())
            launcher.launch(intent)
        }

        findViewById<Button>(R.id.btnExit).setOnClickListener {
            AlertDialog.Builder(this)
                .setTitle("Выход")
                .setIcon(R.drawable.icon)
                .setMessage("Выйти из приложения?")
                .setPositiveButton("OK") { _, _ -> finish() }
                .setNegativeButton("Отмена", null)
                .show()
        }
    }
}