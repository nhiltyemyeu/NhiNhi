package com.example.nhinhi;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    final String DATABASE_NAME = "SinhVien.sqlite";
    SQLiteDatabase database;
    ListView listView;
    ArrayList<SinhVien> list;
    AdapterSinhVien adapter;
    Button btnThem;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        addControls();
        readData();

    }
    private void addControls() {
        listView = (ListView) findViewById(R.id.listView);
        list = new ArrayList<>();
        adapter = new AdapterSinhVien(this, list);
        listView.setAdapter(adapter);
        btnThem=(Button)findViewById(R.id.btnadd);
        btnThem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this, InsertActivity.class);
                startActivity(intent);
            }
        });
    }
    private void readData(){
        database = Database.initDatabase(this, DATABASE_NAME);
        Cursor cursor = database.rawQuery("SELECT * FROM SinhVien",null);
        list.clear();
        for(int i = 0; i < cursor.getCount(); i++){
            cursor.moveToPosition(i);
            int id = cursor.getInt(0);
            String hoten = cursor.getString(1);
            int namsinh = cursor.getInt(2);
            String dienthoai = cursor.getString(3);
            list.add(new SinhVien(id, hoten, namsinh, dienthoai));
        }
        adapter.notifyDataSetChanged();
    }
}