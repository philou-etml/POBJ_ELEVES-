package com.example.mskydraw.notetech;

/**
 * Created by ghadirassadi on 24.08.17.
 */

public class Note_Indust {
    private String name;
    private double note;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getNote() {
        return note;
    }

    public void setNote(double note) {
        this.note = note;
    }

    public Note_Indust(String name, double note) {

        this.name = name;
        this.note = note;
    }

    public Note_Indust() {

    }
}
