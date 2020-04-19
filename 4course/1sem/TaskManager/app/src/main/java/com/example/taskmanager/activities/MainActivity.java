package com.example.taskmanager.activities;

import android.app.DatePickerDialog;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.TimePickerDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.NavigationView;
import android.support.design.widget.TextInputEditText;
import android.support.v4.app.NotificationCompat;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;
import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;

import com.example.taskmanager.R;
import com.example.taskmanager.adapters.PendingTaskAdapter;
import com.example.taskmanager.helpers.DatabaseHelper;
import com.example.taskmanager.helpers.SettingsHelper;
import com.example.taskmanager.helpers.TagDBHelper;
import com.example.taskmanager.helpers.TaskDBHelper;
import com.example.taskmanager.models.PendingTaskModel;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener,
        View.OnClickListener{
    private RecyclerView pendingTasks;
    private LinearLayoutManager linearLayoutManager;
    private ArrayList<PendingTaskModel> pendingTaskModels;
    private ArrayList<PendingTaskModel> modelsToNotif;
    private PendingTaskAdapter pendingTaskAdapter;
    private FloatingActionButton addNewTask;
    private TagDBHelper tagDBHelper;
    private String getTagTitleString;
    private TaskDBHelper taskDBHelper;
    private DatabaseHelper mDBhelper;
    private SQLiteDatabase mDB;
    private LinearLayout linearLayout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SettingsHelper.applyTheme(this);
        setContentView(R.layout.activity_main);
        setSupportActionBar((Toolbar) findViewById(R.id.toolbar));
        SettingsHelper.applyThemeToolbar((Toolbar)findViewById(R.id.toolbar),this);
        setTitle(getString(R.string.app_title));
        showDrawerLayout();
        navigationMenuInit();
        loadPendingTasks();
    }

    //loading all the pending tasks
    private void loadPendingTasks(){
        pendingTasks=(RecyclerView)findViewById(R.id.pending_tasks_view);
        linearLayout=(LinearLayout)findViewById(R.id.no_pending_task_section);
        tagDBHelper=new TagDBHelper(this);
        taskDBHelper=new TaskDBHelper(this);

        if(taskDBHelper.countTasks()==0){
            linearLayout.setVisibility(View.VISIBLE);
            pendingTasks.setVisibility(View.GONE);
        }else {

            pendingTaskModels=new ArrayList<>();
            pendingTaskModels=taskDBHelper.fetchAllTasks();
            pendingTaskAdapter=new PendingTaskAdapter(pendingTaskModels,this);

            int count = taskDBHelper.countTasks();
            String str = String.valueOf(count);

            NotificationCompat.Builder builder =
                    new NotificationCompat.Builder(this)
                            .setSmallIcon(R.drawable.icon)
                            .setOngoing(true)
                            .setContentTitle("Hello!")
                            .setContentText("You still have tasks. Count: " + str + ". Don't forget! ☺" )
                            .setContentInfo("");

            Notification notification = builder.build();

            NotificationManager notificationManager =
                    (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
            notificationManager.notify(1, notification);

        }
            linearLayoutManager = new LinearLayoutManager(this);
            pendingTasks.setAdapter(pendingTaskAdapter);
            pendingTasks.setLayoutManager(linearLayoutManager);
            addNewTask = (FloatingActionButton) findViewById(R.id.fabAddTask);
            addNewTask.setOnClickListener(this);

    }

    @Override
    public void onClick(View view) {
        switch (view.getId()){
            case R.id.fabAddTask:
                if(tagDBHelper.countTags()==0){
                    showDialog();
                }else{
                    showNewTaskDialog();
                }
                break;
        }
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

    //add the drawer layout
    private void showDrawerLayout(){
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer,(Toolbar) findViewById(R.id.toolbar) , R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();
    }

    //initialize navigation menu
    private void navigationMenuInit(){
        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.pending_task_options,menu);
        MenuItem menuItem=menu.findItem(R.id.search);
        SearchView searchView=(SearchView)menuItem.getActionView();
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                newText=newText.toLowerCase();
                ArrayList<PendingTaskModel> newPendingTaskModels=new ArrayList<>();
                for(PendingTaskModel pendingTaskModel:pendingTaskModels){
                    String getTaskTitle=pendingTaskModel.getTaskTitle().toLowerCase();
                    String getTaskContent=pendingTaskModel.getTaskContent().toLowerCase();
                    String getTaskTag=pendingTaskModel.getTaskTag().toLowerCase();

                    if(getTaskTitle.contains(newText) || getTaskContent.contains(newText) || getTaskTag.contains(newText)){
                        newPendingTaskModels.add(pendingTaskModel);
                    }
                }
                pendingTaskAdapter.filterTasks(newPendingTaskModels);
                pendingTaskAdapter.notifyDataSetChanged();
                return true;
            }
        });
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.search:
                return true;
            case R.id.settings:
                startActivity(new Intent(this,AppSettings.class));
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.pending_tasks) {
            startActivity(new Intent(this,MainActivity.class));
        } else if (id == R.id.completed_tasks) {
            startActivity(new Intent(this,CompletedTasks.class));
        } else if (id == R.id.tags) {
            startActivity(new Intent(this,AllTags.class));
        } else if (id == R.id.settings) {
            startActivity(new Intent(this,AppSettings.class));
        }
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    //show dialog if there is no tag in the database
    private void showDialog(){
        AlertDialog.Builder builder=new AlertDialog.Builder(this);
        builder.setTitle(R.string.tag_create_dialog_title_text);
        builder.setMessage(R.string.no_tag_in_the_db_text);
        builder.setPositiveButton(R.string.create_new_tag, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                startActivity(new Intent(MainActivity.this,AllTags.class));
            }
        }).setNegativeButton(R.string.tag_edit_cancel, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {

            }
        }).create().show();
    }

    //show add new task dialog and adding the task into the database
    private void showNewTaskDialog(){
        //getting current calendar credentials
        final Calendar calendar=Calendar.getInstance();
        final int year=calendar.get(Calendar.YEAR);
        final int month=calendar.get(Calendar.MONTH);
        final int day=calendar.get(Calendar.DAY_OF_MONTH);
        final int hour=calendar.get(Calendar.HOUR);
        final int minute=calendar.get(Calendar.MINUTE);

        final AlertDialog.Builder builder=new AlertDialog.Builder(this);
        LayoutInflater layoutInflater=(LayoutInflater)getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        final View view=layoutInflater.inflate(R.layout.add_new_task_dialog,null);
        builder.setView(view);
        SettingsHelper.applyThemeTextView((TextView)view.findViewById(R.id.add_task_dialog_title),this);
        final TextInputEditText taskTitle=(TextInputEditText)view.findViewById(R.id.task_title);
        final TextInputEditText taskContent=(TextInputEditText)view.findViewById(R.id.task_content);
        Spinner taskTags=(Spinner)view.findViewById(R.id.task_tag);
        //stores all the tags title in string format
        ArrayAdapter<String> tagsModelArrayAdapter=new ArrayAdapter<String>(this,android.R.layout.simple_spinner_dropdown_item,tagDBHelper.fetchTagStrings());
        //setting dropdown view resouce for spinner
        tagsModelArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //setting the spinner adapter
        taskTags.setAdapter(tagsModelArrayAdapter);
        taskTags.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                getTagTitleString=adapterView.getItemAtPosition(i).toString();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
        final TextInputEditText taskDate=(TextInputEditText)view.findViewById(R.id.task_date);
        final TextInputEditText taskTime=(TextInputEditText)view.findViewById(R.id.task_time);

        //getting the taskdate
        taskDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatePickerDialog datePickerDialog=new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                        calendar.set(Calendar.YEAR,i);
                        calendar.set(Calendar.MONTH,i1);
                        calendar.set(Calendar.DAY_OF_MONTH,i2);
                        taskDate.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(calendar.getTime()));
                    }
                },year,month,day);
                datePickerDialog.show();
            }
        });

        //getting the tasks time
        taskTime.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                TimePickerDialog timePickerDialog=new TimePickerDialog(MainActivity.this, new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker timePicker, int i, int i1) {
                        calendar.set(Calendar.HOUR_OF_DAY,i);
                        calendar.set(Calendar.MINUTE,i1);
                        String timeFormat=DateFormat.getTimeInstance(DateFormat.SHORT).format(calendar.getTime());
                        taskTime.setText(timeFormat);
                    }
                },hour,minute,true);
                timePickerDialog.show();
            }
        });
        TextView cancel=(TextView)view.findViewById(R.id.cancel);
        TextView addTask=(TextView)view.findViewById(R.id.add_new_task);
        SettingsHelper.applyTextColor(cancel,this);
        SettingsHelper.applyTextColor(addTask,this);
        addTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //getting all the values from add new tasks dialog
                String getTaskTitle=taskTitle.getText().toString();
                String getTaskContent=taskContent.getText().toString();
                int taskTagID=tagDBHelper.fetchTagID(getTagTitleString);
                String getTaskDate=taskDate.getText().toString();
                String getTime=taskTime.getText().toString();

                //checking the data fiels
                boolean isTitleEmpty=taskTitle.getText().toString().isEmpty();
                boolean isContentEmpty=taskContent.getText().toString().isEmpty();
                boolean isDateEmpty=taskDate.getText().toString().isEmpty();
                boolean isTimeEmpty=taskTime.getText().toString().isEmpty();

                //adding the tasks
                if(isTitleEmpty){
                    taskTitle.setError("Enter title!");
                }else if(isContentEmpty){
                    taskContent.setError("Enter your task!");
                }else if(isDateEmpty){
                    taskDate.setError("Enter date!");
                }else if(isTimeEmpty){
                    taskTime.setError("Enter time!");
                }else if(taskDBHelper.addNewTask(
                        new PendingTaskModel(getTaskTitle,getTaskContent,String.valueOf(taskTagID),getTaskDate,getTime)
                )){
                    Toast.makeText(MainActivity.this, R.string.task_title_add_success_msg, Toast.LENGTH_SHORT).show();
                    startActivity(new Intent(MainActivity.this,MainActivity.class));
                }
            }
        });
        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(MainActivity.this,MainActivity.class));
            }
        });
        builder.create().show();
    }
}
