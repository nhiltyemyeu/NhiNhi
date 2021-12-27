package com.example.nhinhi;

import androidx.appcompat.app.AppCompatActivity;
import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;

import java.io.ByteArrayOutputStream;

public class UpdateActivity extends AppCompatActivity{
    final String DATABASE_NAME = "SinhVien.sqlite";
    int id = -1;
    Button btnLuu, btnHuy;
    EditText edtTen, edtns, edtsdt;
    ImageView imgHinhDaiDien;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update);
        addControls();
        addEvents();
        initUI();
    }
    private void addControls() {
        btnLuu = (Button) findViewById(R.id.btnLuu);
        btnHuy = (Button) findViewById(R.id.btnHuy);
        edtTen = (EditText) findViewById(R.id.edtTen);
        edtns = (EditText) findViewById(R.id.edtns);
        edtsdt = (EditText) findViewById(R.id.edtsdt);
        imgHinhDaiDien = (ImageView) findViewById(R.id.imgHinhDaiDien);
    }
    private void addEvents(){
        btnLuu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                update();
            }
        });
        btnHuy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cancel();
            }
        });
    }
    private void initUI() {
        Intent intent = getIntent();
        id = intent.getIntExtra("MaSV", -1);
        SQLiteDatabase database = Database.initDatabase(this, DATABASE_NAME);
        Cursor cursor = database.rawQuery("SELECT * FROM SinhVien WHERE MaSV = ? ",new String[]{id + ""});
        cursor.moveToFirst();
        String ten = cursor.getString(1);
        String ns = cursor.getString(2);
        String sdt = cursor.getString(3);
        edtTen.setText(ten);
        edtns.setText(ns);
        edtsdt.setText(sdt);
    }
    private void update(){
        BitmapDrawable bitmapDrawable = (BitmapDrawable) imgHinhDaiDien.getDrawable();
        Bitmap bitmap = bitmapDrawable.getBitmap();
        ByteArrayOutputStream byteArray = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG,100,byteArray);
        byte[] hinh =byteArray.toByteArray();
        String ten = edtTen.getText().toString();
        String ns = edtns.getText().toString();
        String sdt = edtsdt.getText().toString();
        ContentValues contentValues = new ContentValues();
        contentValues.put("HoTen", ten);
        contentValues.put("namsinh", ns);
        contentValues.put("dienthoai", sdt);
        contentValues.put("hinh", hinh);
        SQLiteDatabase database = Database.initDatabase(this, "SinhVien.sqlite");
        database.update("SinhVien", contentValues, "MaSV = ?", new String[]{id + ""});
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }


    private void cancel(){
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}
