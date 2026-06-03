package com.example.zametki

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity

class SecondActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)

        val txtTitle = findViewById<EditText>(R.id.txtTitle)
        val txtContent = findViewById<EditText>(R.id.txtContent)
        val index = intent.getIntExtra("index", -1)

        txtTitle.setText(intent.getStringExtra("title") ?: "")
        txtContent.setText(intent.getStringExtra("content") ?: "")

        findViewById<Button>(R.id.btnSave).setOnClickListener {
            val result = Intent()
            result.putExtra("title", txtTitle.text.toString())
            result.putExtra("content", txtContent.text.toString())
            result.putExtra("index", index)
            setResult(Activity.RESULT_OK, result)
            finish()
        }

        findViewById<Button>(R.id.btnCancel).setOnClickListener { finish() }
    }
}