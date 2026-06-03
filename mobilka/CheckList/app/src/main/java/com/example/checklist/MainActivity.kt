package com.example.checklist

import android.os.Bundle
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    private lateinit var etPriceApple : EditText;
    private lateinit var etPriceStraw : EditText;
    private lateinit var etPriceBlue : EditText;
    private lateinit var etPricePotat : EditText;

    private lateinit var etApple : EditText;
    private lateinit var etStraw : EditText;
    private lateinit var etBlue : EditText;
    private lateinit var etPotat : EditText;


    private lateinit var cbApple : CheckBox;
    private lateinit var cbStraw : CheckBox;
    private lateinit var cbBlue : CheckBox;
    private lateinit var cbPotat : CheckBox;


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        etPriceApple = findViewById(R.id.etPriceApple)
        etPriceStraw = findViewById(R.id.etPriceStraw)
        etPriceBlue = findViewById(R.id.etPriceBlue)
        etPricePotat = findViewById(R.id.etPricePotat)

        etApple = findViewById(R.id.etApple)
        etStraw = findViewById(R.id.etStraw)
        etBlue = findViewById(R.id.etBlue)
        etPotat = findViewById(R.id.etPotat)

        cbApple = findViewById(R.id.cbApple)
        cbStraw = findViewById(R.id.cbStraw)
        cbBlue = findViewById(R.id.cbBlue)
        cbPotat = findViewById(R.id.cbPotat)

        findViewById<Button>(R.id.btnCalc).setOnClickListener { calcCheck() }

    }


    private fun calcCheck()
    {
        val cbList = listOf(cbApple, cbStraw, cbBlue, cbPotat)
        val priceList = listOf(etPriceApple, etPriceStraw, etPriceBlue, etPricePotat)
        val countList = listOf(etApple, etStraw, etBlue, etPotat)
        val names = listOf("Apple", "Strawberry", "Blueberry", "Potatoes")

        var total = 0.0;
        val nds = 0.20;
        var message = ""
        for(i in 0..3)
        {
            if(!cbList[i].isChecked) continue

            val count = countList[i].text.toString().toIntOrNull()
            val price = priceList[i].text.toString().toDoubleOrNull()


            if(price == null)
            {
                message = "Цена не указана | ${names[i]}"

                AlertDialog.Builder(this@MainActivity)
                    .setTitle("Ошибка")
                    .setIcon(R.drawable.iconka)
                    .setMessage(message)
                    .setPositiveButton("ОК", null)
                    .show()
                return
            }

            if(count == null)
            {

                message = "Количество не указано | ${names[i]}"
                AlertDialog.Builder(this@MainActivity)
                    .setTitle("Ошибка")
                    .setIcon(R.drawable.iconka)
                    .setMessage(message)
                    .setPositiveButton("ОК", null)
                    .show()
                return
            }

            val sum = count * price;

            total += sum;

            message += "${names[i]} : ${count} * ${price} = ${sum} \n"


        }

        if(message.isEmpty())
        {
            AlertDialog.Builder(this)
                .setTitle("Ошибка")
                .setIcon(R.drawable.iconka)
                .setMessage("Выберите хотябы один товар")
                .setPositiveButton("Ok", null )
                .show()
            return
        }

        val totalnds = total + nds
        message += "Итоговая стоимость: ${total} + ${nds} = ${totalnds}"

        AlertDialog.Builder(this)
            .setTitle("Чек")
            .setIcon(R.drawable.iconka)
            .setMessage(message)
            .setPositiveButton("Ok", null )
            .show()

    }
}