package com.example.mskydraw.notetech;


import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import static android.content.Context.MODE_PRIVATE;

public class Main_content extends Fragment {

    TextView Nxt;
    TextView txt_2;
    String MY_PREFS_NAME = "TestName";
    String stringToSave;
    String saveKey = "TestKey";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_main_content, container, false);

        return view;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        Nxt = (TextView) view.getRootView().findViewById(R.id.TxtView);
        txt_2 = (TextView) view.getRootView().findViewById(R.id.txt2);

        Bundle bundle = getArguments();
        if (bundle != null) {
            float note = bundle.getFloat("N1");
            Nxt.setText("Int received from Bundle: " + String.valueOf(note));
            Toast.makeText(getContext(), "Note: " + note, Toast.LENGTH_SHORT).show();
            stringToSave = String.valueOf(note);
            // To save data to SP
            SharedPreferences.Editor editor = getContext().getSharedPreferences(MY_PREFS_NAME, MODE_PRIVATE).edit();
            editor.putString(saveKey, stringToSave);
            editor.apply();
        }

        // To load the data at a later time
        SharedPreferences prefs = getContext().getSharedPreferences(MY_PREFS_NAME, MODE_PRIVATE);
        String loadedString = prefs.getString(saveKey, null);
        txt_2.setText("Int loaded from Shared Preferences: " + loadedString);
    }

}