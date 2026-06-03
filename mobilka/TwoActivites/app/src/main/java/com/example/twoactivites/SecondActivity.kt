package com.example.twoactivites

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity

class SecondActivity : AppCompatActivity() {

    private lateinit var txtData2: EditText

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)

        txtData2 = findViewById(R.id.txtData2)

        val received = intent.getStringExtra("data") ?: ""
        txtData2.setText(received)

        findViewById<Button>(R.id.btnOk).setOnClickListener {
            val result = Intent()
            result.putExtra("result", txtData2.text.toString())
            setResult(Activity.RESULT_OK, result)
            finish()
        }

        findViewById<Button>(R.id.btnBack).setOnClickListener {
            finish()
        }
    }
}