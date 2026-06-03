package com.example.elementslist

import android.os.Bundle
import android.view.View
import android.view.ViewParent
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import android.widget.Spinner
import android.widget.SpinnerAdapter
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    private lateinit var lvTodo: ListView
    private val items = mutableListOf<String>()
    private lateinit var adapter: ArrayAdapter<String>
    private var selectedIndex = -1

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        lvTodo = findViewById(R.id.lvTodo)
        adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, items)
        lvTodo.adapter = adapter

        lvTodo.setOnItemClickListener { _, _, position, _ ->
            selectedIndex = position
        }

        findViewById<Button>(R.id.btnAdd).setOnClickListener { addItem() }
        findViewById<Button>(R.id.btnEdit).setOnClickListener { editItem() }
        findViewById<Button>(R.id.btnDelete).setOnClickListener { deleteItem() }
    }

    private fun addItem() {
        val input = EditText(this)
        AlertDialog.Builder(this)
            .setTitle("Добавить задачу")
            .setView(input)
            .setPositiveButton("OK") { _, _ ->
                val text = input.text.toString()
                if (text.isNotEmpty()) {
                    items.add(text)
                    adapter.notifyDataSetChanged()
                }
            }
            .setNegativeButton("Отмена", null)
            .show()
    }

    private fun editItem() {
        if (selectedIndex == -1) return
        val input = EditText(this)
        input.setText(items[selectedIndex])
        AlertDialog.Builder(this)
            .setTitle("Изменить задачу")
            .setView(input)
            .setPositiveButton("OK") { _, _ ->
                val text = input.text.toString()
                if (text.isNotEmpty()) {
                    items[selectedIndex] = text
                    adapter.notifyDataSetChanged()
                }
            }
            .setNegativeButton("Отмена", null)
            .show()
    }

    private fun deleteItem() {
        if (selectedIndex == -1) return
        AlertDialog.Builder(this)
            .setTitle("Удаление")
            .setIcon(R.drawable.iconka)
            .setMessage("Удалить '${items[selectedIndex]}'?")
            .setPositiveButton("OK") { _, _ ->
                items.removeAt(selectedIndex)
                adapter.notifyDataSetChanged()
                selectedIndex = -1
            }
            .setNegativeButton("Отмена", null)
            .show()
    }
}