package com.example.zametki;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class DB extends SQLiteOpenHelper {

    private static final String DB_NAME = "dictionary.db";
    private static final int DB_VERSION = 1;

    public DB(@Nullable Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql = "CREATE TABLE dictionary (my_key TEXT PRIMARY KEY, my_value TEXT);";
        db.execSQL(sql);
    }

    public boolean keyExists(String key) {
        String sql = "SELECT my_key FROM dictionary WHERE my_key = '" + escape(key) + "';";
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor = db.rawQuery(sql, null);
        boolean exists = cursor.moveToFirst();
        cursor.close();
        return exists;
    }

    public void insert(String key, String value) {
        String sql = "INSERT INTO dictionary VALUES('" + escape(key) + "', '" + escape(value) + "');";
        SQLiteDatabase db = getWritableDatabase();
        db.execSQL(sql);
    }

    @Nullable
    public String select(String key) {
        String sql = "SELECT my_value FROM dictionary WHERE my_key = '" + escape(key) + "';";
        SQLiteDatabase db = getReadableDatabase();
        Cursor cursor = db.rawQuery(sql, null);
        if (cursor.moveToFirst()) {
            String value = cursor.getString(0);
            cursor.close();
            return value;
        }
        cursor.close();
        return null;
    }

    public void update(String key, String value) {
        String sql = "UPDATE dictionary SET my_value = '" + escape(value)
                + "' WHERE my_key = '" + escape(key) + "';";
        SQLiteDatabase db = getWritableDatabase();
        db.execSQL(sql);
    }

    public void delete(String key) {
        String sql = "DELETE FROM dictionary WHERE my_key = '" + escape(key) + "';";
        SQLiteDatabase db = getWritableDatabase();
        db.execSQL(sql);
    }

    private static String escape(String value) {
        return value.replace("'", "''");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
    }
}
