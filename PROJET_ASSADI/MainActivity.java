package com.example.mskydraw.notetech;

import android.content.SharedPreferences;
import android.content.pm.FeatureGroupInfo;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import static java.security.AccessController.getContext;


public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);



        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        setTitle("Main");
        Main_content newmain = new Main_content();
        FragmentManager fragmentManager = getSupportFragmentManager();
        fragmentManager.beginTransaction().replace(R.id.fragment, newmain,newmain.getTag()).addToBackStack(null).commit();








    }




    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        FragmentManager fragmentManager = getSupportFragmentManager();

        if (id == R.id.MAIN_CONTENT)
        {
            setTitle("Main");
            Main_content newmain = new Main_content();
            fragmentManager.beginTransaction().replace(R.id.fragment, newmain,newmain.getTag()).addToBackStack(null).commit();
        }
        else if (id == R.id.cofo) {
            setTitle("COFO");
            Cofo newcofo = new Cofo();

            fragmentManager.beginTransaction().replace(R.id.fragment,newcofo,newcofo.getTag()).addToBackStack(null).commit();


        } else if (id == R.id.elec) {
            setTitle("GELEC");
            Gelec newgelec = new Gelec();

            fragmentManager.beginTransaction().replace(R.id.fragment,newgelec,newgelec.getTag()).addToBackStack(null).commit();

            setTitle("GLOG");
            Glog newglog = Glog.newInstance("some1","some2");

            fragmentManager.beginTransaction().replace(R.id.fragment,newglog).addToBackStack(null).commit();

        } else if (id == R.id.indust) {
            setTitle("INDUST");
            Indust newindust = new Indust();

            fragmentManager.beginTransaction().replace(R.id.fragment,newindust).addToBackStack(null).commit();

        } else if (id == R.id.phys) {
            setTitle("TA PHYS");
            TA_phys newTAphys = new TA_phys();

            fragmentManager.beginTransaction().replace(R.id.fragment,newTAphys).addToBackStack(null).commit();

        } else if (id == R.id.math) {
            setTitle("TA MATH");
            TA_math newTAmath = new TA_math();

            fragmentManager.beginTransaction().replace(R.id.fragment,newTAmath).addToBackStack(null).commit();

        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
