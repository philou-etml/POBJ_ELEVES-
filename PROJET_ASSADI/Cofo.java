
package com.example.mskydraw.notetech;



        import android.content.Context;
        import android.content.SharedPreferences;
        import android.os.Bundle;
        import android.support.design.widget.FloatingActionButton;
        import android.support.v4.app.Fragment;
        import android.support.v4.app.FragmentManager;
        import android.text.method.ScrollingMovementMethod;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.ArrayAdapter;
        import android.widget.AutoCompleteTextView;
        import android.widget.Button;
        import android.widget.EditText;
        import android.widget.Gallery;
        import android.widget.Spinner;
        import android.widget.TextView;
        import android.widget.Toast;
        import android.widget.ScrollView;
        import android.widget.LinearLayout;
        import android.widget.CheckBox;
        import java.io.FileOutputStream;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.StringTokenizer;

        import static android.content.Context.MODE_PRIVATE;


/**
 * A simple {@link Fragment} subclass.
 */


public class Cofo extends Fragment {




    public Cofo() {
        // Required empty public constructor
    }

    //EditText Fo_note,T_note,S_note,F_note;
    //Button newSaveme;
    //Button newload;
    Button newBtn;
    float result;
    //Dynamic variable
    float Counter_Note;
    float Note_init, Note_Fin;
    Button newbtnAdd;
    AutoCompleteTextView textIn;
    LinearLayout _container;


    //Dynamic array
    private static final Double[] NUMBER = new Double[]{
        1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0
    };
    ArrayAdapter<Double> adapter_Dyn;

    // Decalaration for spinner
    Spinner spinner;
    private static final Double[] Array_note = new Double[]{1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0};
    ArrayAdapter<Double> adapter;

    //List<Double> list=new ArrayList<>();
    //double i=1.0;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        //Dynamic
        //Be aware, since you're coding in a fragment (this) must be replace by getActivity()

        // Ajusting array NUMBER with adapter_Dyn
        adapter_Dyn = new ArrayAdapter<Double>(getActivity(), android.R.layout.simple_dropdown_item_1line,Array_note);



        // Inflate the layout for this fragment
        // Allows to use view.findViewById
        final View view = inflater.inflate(R.layout.fragment_cofo, container, false);

        // finding my bouton and text on layout

        spinner = (Spinner)view.findViewById(R.id.Sp_Note);


        newBtn = (Button)view.findViewById(R.id.Btn);



        //Setting up the spinner with the array
        adapter = new ArrayAdapter<Double>(getActivity(),android.R.layout.simple_spinner_item,Array_note);
        adapter.setDropDownViewResource(android.R.layout.simple_list_item_1);
        spinner.setAdapter(adapter_Dyn);


        //Dynamic

        // Identifying AutocompeleteView on fragment_cofo
        textIn = (AutoCompleteTextView)view.findViewById(R.id.textin);
        // Setting adapter_Dyn into textIn which is conncected to AutoCompl of fragment_cofo
        textIn.setAdapter(adapter_Dyn);

        newbtnAdd = (Button)view.findViewById(R.id.buttonAdd); // Button for adding new note
        _container = (LinearLayout)view.findViewById(R.id.container_n);

        newbtnAdd.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                LayoutInflater layoutInflater =
                        (LayoutInflater)getActivity().getBaseContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                final View addView = layoutInflater.inflate(R.layout.row, null);
                AutoCompleteTextView textOut = (AutoCompleteTextView)addView.findViewById(R.id.textout2);
                textOut.setAdapter(adapter_Dyn);
                //textOut.setText(textIn.getText().toString());
                textOut.setText(spinner.getSelectedItem().toString());

                Note_init = Float.valueOf(textIn.getText().toString());
                Button buttonRemove = (Button)addView.findViewById(R.id.remove);

                Note_Fin = Note_init + Note_Fin;
                Counter_Note = Counter_Note + 1;

                final View.OnClickListener thisListener = new View.OnClickListener(){
                    @Override
                    public void onClick(View v) {
                        ((LinearLayout)addView.getParent()).removeView(addView);
                    }
                };

                buttonRemove.setOnClickListener(thisListener);
                _container.addView(addView);



            }
        });
        //==========================================================================================



        // whenever I click on the bouton
        newBtn.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){



                result = Float.valueOf(Note_Fin / Counter_Note);



                //This code allows you to jump into another fragment
                // Call the fragment to where I want to jump
                Main_content newmain = new Main_content();

                //Here we are going to learn to how to save data
                // Create an object output string


                //here we are sending data to another fragment
                //You have declare bundle
                Bundle bundle = new Bundle();
                // You can use bundle.putxx everything such as String...float..
                bundle.putFloat("N1",result);
                //calling the fragment I'm going to send the data
                // and I'm going to send data I saved on bundle.
                newmain.setArguments(bundle);
                // The process of declaration fragment
                FragmentManager manager = getFragmentManager();
                // Jumping into main content fragment
                manager.beginTransaction().replace(R.id.fragment,newmain,newmain.getTag()).addToBackStack(null).commit();

                /*if (F_note.getText().toString().equals("Hello")){
                    Toast.makeText(Cofo.this.getActivity(), "true", Toast.LENGTH_SHORT).show();
                }
                else{
                    Toast.makeText(Cofo.this.getActivity(), "Hi", Toast.LENGTH_SHORT).show();
                }*/

            }
        });

        return view;

    }
}