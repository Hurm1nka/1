package com.example.calculator

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import kotlin.math.E
import kotlin.math.PI
import kotlin.math.cos
import kotlin.math.sin
import kotlin.math.tan

class MainActivity : AppCompatActivity() {

    private lateinit var etNum1 : EditText;
    private lateinit var etNum2 : EditText;
    private lateinit var tvResult : TextView;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        etNum1 = findViewById(R.id.etA)
        etNum2 = findViewById(R.id.etB)
        tvResult = findViewById(R.id.tvResult)

        findViewById<Button>(R.id.btnAdd).setOnClickListener { calculate("+") }
        findViewById<Button>(R.id.btnSubtract).setOnClickListener { calculate("-") }
        findViewById<Button>(R.id.btnDivide).setOnClickListener { calculate("/") }
        findViewById<Button>(R.id.btnMultiply).setOnClickListener { calculate("*") }

        findViewById<Button>(R.id.btnSin).setOnClickListener { trigan("sin") }
        findViewById<Button>(R.id.btnCos).setOnClickListener { trigan("cos") }
        findViewById<Button>(R.id.btnTan).setOnClickListener { trigan("tan") }
        findViewById<Button>(R.id.btnPi).setOnClickListener { oneOper("pi") }
        findViewById<Button>(R.id.btnE).setOnClickListener { oneOper("e") }
    }

    private fun calculate(op : String)
    {
        val str1 = etNum1.text.toString();
        val str2 = etNum2.text.toString()

        val a = str1.toDoubleOrNull()
        val b = str2.toDoubleOrNull()

        if(a == null || b == null)
        {
            tvResult.text = "Поля не заполены"
            return
        }

        if(op == "/" && b == 0.0)
        {
            tvResult.text = "На ноль делить нельзя"
            return
        }

        val result = when(op)
        {
            "+" -> a + b;
            "-" -> a - b;
            "/" -> a / b;
            "*" -> a * b;

            else -> return
        }

        tvResult.setText(result.toString())

    }


    private fun trigan(op : String)
    {
        val str1 = etNum1.text.toString()

        val a = str1.toDoubleOrNull();


        if(a == null)
        {
          tvResult.setText("Ошибка поле А пустое")
            return;
        }

        val result = when(op)
        {
            "sin" -> sin(Math.toRadians(a));
            "cos" -> cos(Math.toRadians(a));
            "tan" ->
            {
                val res = tan(Math.toRadians(a))
                if(Math.abs(res) > 1e10) // 90, 270, 450
                {
                    "tan не определен";
                }
                else
                {
                    res
                }

            }
            else -> return
        }

        tvResult.setText(result.toString())
    }


    private fun oneOper(op : String)
    {

       val result = when(op)
        {
            "pi" -> PI;
            "e" -> E;
            else -> return
        }

        etNum1.setText(result.toString())

    }


}