package com.example.nhinhi;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;

public class InsertActivity extends AppCompatActivity {
    final String DATABASE_NAME = "SinhVien.sqlite";
    Button btnThem, btnHuy;
    EditText edtTen, edtSdt,edtId,edtold;
    ImageButton imgbtn1;
    ImageView imgview;
    int REQUEST_CODE_FOLDER= 456;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_insert);
        addControls();
        addEvents();
    }
    private void addControls() {
        btnThem = (Button) findViewById(R.id.btnThem);
        btnHuy = (Button) findViewById(R.id.btnHuy);
        edtTen = (EditText) findViewById(R.id.edtTen);
        edtSdt = (EditText)findViewById(R.id.edtSdt);
        edtId =(EditText)findViewById(R.id.edtid);
        edtold=(EditText)findViewById(R.id.edtOld);
        imgbtn1 = (ImageButton) findViewById(R.id.imageButton1);
    }
    private void addEvents(){
        btnThem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                insert();
            }
        });
        btnHuy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cancel();
            }
        });
    }
    private void insert(){
        String ten = edtTen.getText().toString();
        String sdt = edtSdt.getText().toString();
        String id = edtId.getText().toString();
        String Old = edtold.getText().toString();
        ContentValues contentValues = new ContentValues();
        contentValues.put("MASV", id);
        contentValues.put("HoTen", ten);
        contentValues.put("NamSinh", Old);
        contentValues.put("DienThoai", sdt);
        SQLiteDatabase database = Database.initDatabase(this, DATABASE_NAME);

        database.insert("SinhVien", null, contentValues);
        Log.e("Contact Entered", "DATABASE");
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
    private void cancel(){
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}