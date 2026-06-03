package com.example.converter

import android.os.Bundle
import android.view.View
import android.view.ViewParent
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import android.widget.SpinnerAdapter
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

     private lateinit var etFrom : EditText;
     private lateinit var tvTo : TextView
     private lateinit var spChange : Spinner;
     private lateinit var spFrom : Spinner;
     private lateinit var spTo : Spinner;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        var changeList = listOf<String>("Distance", "Information")
        var distanceList = listOf<String>("mm", "cm", "m", "km")
        var infoList = listOf<String>("bit", "byte", "kb", "mb", "gb")

        etFrom = findViewById(R.id.etFrom)
        tvTo = findViewById(R.id.tvTo)
        spChange = findViewById(R.id.spChange);
        spFrom = findViewById(R.id.spFrom);
        spTo = findViewById(R.id.spTo);

        val changeAdapter = ArrayAdapter(this, android.R.layout.simple_spinner_item, changeList)
        // changeAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        spChange.adapter = changeAdapter


        spChange.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {

            override fun onItemSelected(p0: AdapterView<*>?, p1: View?, p2: Int, p3: Long) {
                val list = if(p2 == 0) distanceList else infoList
                val adapter = ArrayAdapter(this@MainActivity, android.R.layout.simple_spinner_item, list);
                spFrom.adapter = adapter;
                spTo.adapter = adapter;
            }

            override fun onNothingSelected(p0: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        findViewById<Button>(R.id.btnConvert).setOnClickListener { converting() }

    }

    private fun converting()
    {

        val textFrom = etFrom.text.toString();

        if(textFrom.isEmpty())
        {
            tvTo.setText(getString(R.string.empty))
            return
        }

        val num = textFrom.toDoubleOrNull()

        if(num == null)
        {
            tvTo.setText(getString(R.string.noNum))
            return
        }

        if(num < 0.0)
        {
            tvTo.setText(getString(R.string.negNum))
            return
        }

        val mapDistance = mapOf(

            "mm" to 0.001,
            "cm" to 0.01,
            "m" to 1.0,
            "km" to 1000.0
        )

        val mapInfromation = mapOf(
            "bit" to 1.0,
            "byte" to 8.0,
            "kb" to 8.0 * 1024,
            "mb" to 8.0 * 1024 * 1024,
            "gb" to 8.0 * 1024 * 1024 * 1024
        )

        val from = spFrom.selectedItem.toString()
        val to = spTo.selectedItem.toString()

        val result = if(spChange.selectedItem.toString() == "Distance")
        {
            num * (mapDistance[from] ?: 1.0) / (mapDistance[to] ?: 1.0)
        }
        else
        {
            num * (mapInfromation[from] ?: 1.0) / (mapInfromation[to] ?: 1.0)
        }

        tvTo.setText("%.8f".format(result))

    }

}