package com.example.zametki

import android.app.Activity
import android.app.AlertDialog
import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import androidx.activity.enableEdgeToEdge
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    private lateinit var lstNotes: ListView
    private val notes = mutableListOf<Note>()
    private lateinit var adapter: ArrayAdapter<String>
    private var selectedIndex = -1

    private val launcher = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            val title = result.data?.getStringExtra("title") ?: ""
            val content = result.data?.getStringExtra("content") ?: ""
            val index = result.data?.getIntExtra("index", -1) ?: -1
            if (index == -1) {
                notes.add(Note(title, content))
            } else {
                notes[index] = Note(title, content)
            }
            refreshList()
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        lstNotes = findViewById(R.id.lstNotes)
        adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, mutableListOf())
        lstNotes.adapter = adapter

        lstNotes.setOnItemClickListener { _, _, position, _ -> selectedIndex = position }

        findViewById<Button>(R.id.btnNew).setOnClickListener {
            val intent = Intent(this, SecondActivity::class.java)
            intent.putExtra("index", -1)
            launcher.launch(intent)
        }

        findViewById<Button>(R.id.btnEdit).setOnClickListener {
            if (selectedIndex == -1) return@setOnClickListener
            val intent = Intent(this, SecondActivity::class.java)
            intent.putExtra("title", notes[selectedIndex].title)
            intent.putExtra("content", notes[selectedIndex].content)
            intent.putExtra("index", selectedIndex)
            launcher.launch(intent)
        }

        findViewById<Button>(R.id.btnDelete).setOnClickListener {
            if (selectedIndex == -1) return@setOnClickListener
            AlertDialog.Builder(this)
                .setTitle("Удаление")
                .setIcon(R.drawable.image)
                .setMessage("Удалить '${notes[selectedIndex].title}'?")
                .setPositiveButton("OK") { _, _ ->
                    notes.removeAt(selectedIndex)
                    selectedIndex = -1
                    refreshList()
                }
                .setNegativeButton("Отмена", null)
                .show()
        }
    }

    private fun refreshList() {
        adapter.clear()
        adapter.addAll(notes.map { "${it.title}\n${it.content}" })
        adapter.notifyDataSetChanged()
    }
}