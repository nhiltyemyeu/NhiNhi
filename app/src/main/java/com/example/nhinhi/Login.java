package com.example.nhinhi;



import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.example.nhinhi.MainActivity;

public class Login extends AppCompatActivity {


    final String DATABASE_NAME = "SinhVien.sqlite";
    String user;
    String password;
    int id;
    SQLiteDatabase database;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Button Login = (Button) findViewById(R.id.btnlogin);
        EditText edtuser = (EditText) findViewById(R.id.email);
        EditText edtpass = (EditText) findViewById(R.id.pass);
        database = Database.initDatabase(this, DATABASE_NAME);



        Login.setOnClickListener(new View.OnClickListener() {

            @Override

            public void onClick(View view) {

                Cursor cursor = database.rawQuery("SELECT * FROM User", null);
                String user;
                String pass;

                String User = edtuser.getText().toString();
                String Pass = edtpass.getText().toString();
                for(int i = 0; i < cursor.getCount(); i++){
                    cursor.moveToPosition(i);
                    user=cursor.getString(1);
                    pass=cursor.getString(2);

                    if (User.equalsIgnoreCase(user) && Pass.equalsIgnoreCase(pass)) {
                        Intent intent = new Intent(Login.this, MainActivity.class);
                        startActivity(intent);
                        break;
                    }
                    if(i==cursor.getCount()-1){
                        TextView btnerr = (TextView) findViewById(R.id.err);
                        btnerr.setText("Sai tai khoan hoac mat khau");

                    }
                }
            }
        });
        TextView btn = findViewById(R.id.signup);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(Login.this, RegisterActivity.class));
            }
        });
    }
}