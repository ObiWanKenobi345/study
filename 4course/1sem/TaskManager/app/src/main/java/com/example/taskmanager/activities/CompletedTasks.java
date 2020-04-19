package com.example.taskmanager.activities;

import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.example.taskmanager.R;
import com.example.taskmanager.adapters.CompletedTaskAdapter;
import com.example.taskmanager.helpers.SettingsHelper;
import com.example.taskmanager.helpers.TaskDBHelper;
import com.example.taskmanager.models.CompletedTaskModel;

import java.util.ArrayList;

public class CompletedTasks extends AppCompatActivity {
    private RecyclerView completedTasks;
    private LinearLayoutManager linearLayoutManager;
    private ArrayList<CompletedTaskModel> completedTaskModels;
    private CompletedTaskAdapter completedTaskAdapter;
    private LinearLayout linearLayout;
    private TaskDBHelper taskDBHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SettingsHelper.applyTheme(this);
        setContentView(R.layout.activity_completed_tasks);
        setSupportActionBar((Toolbar)findViewById(R.id.toolbar));
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        SettingsHelper.applyThemeToolbar((Toolbar)findViewById(R.id.toolbar),this);
        setTitle(getString(R.string.complete_task_activity_title));
        loadCompletedTasks();
    }

    //loading all the completed tasks
    private void loadCompletedTasks(){
        completedTasks=(RecyclerView)findViewById(R.id.completed_tasks_view);
        taskDBHelper=new TaskDBHelper(this);
        linearLayout=(LinearLayout)findViewById(R.id.no_completed_task_section) ;
        if(taskDBHelper.countCompletedTasks()==0){
            linearLayout.setVisibility(View.VISIBLE);
            completedTasks.setVisibility(View.GONE);
        }else{
            linearLayout.setVisibility(View.GONE);
            completedTasks.setVisibility(View.VISIBLE);
            completedTaskModels=new ArrayList<>();
            completedTaskModels=taskDBHelper.fetchCompletedTasks();
            completedTaskAdapter=new CompletedTaskAdapter(completedTaskModels,this);
        }
        linearLayoutManager=new LinearLayoutManager(this);
        completedTasks.setAdapter(completedTaskAdapter);
        completedTasks.setLayoutManager(linearLayoutManager);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.completed_task_options,menu);
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
                ArrayList<CompletedTaskModel> newCompletedTaskModels=new ArrayList<>();
                for(CompletedTaskModel completedTaskModel:completedTaskModels){
                    String getTaskTitle=completedTaskModel.getTaskTitle();
                    String getTaskContent=completedTaskModel.getTaskContent();
                    String getTaskTag=completedTaskModel.getTaskTag();

                    if(getTaskTitle.contains(newText) || getTaskContent.contains(newText) || getTaskTag.contains(newText)){
                        newCompletedTaskModels.add(completedTaskModel);
                    }
                }
                completedTaskAdapter.filterCompletedTasks(newCompletedTaskModels);
                completedTaskAdapter.notifyDataSetChanged();
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
            case R.id.delete_all:
                deleteDialog();
                return true;
            case R.id.settings:
                startActivity(new Intent(this,AppSettings.class));
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    //showing the delete confirmation dialog
    private void deleteDialog(){
        AlertDialog.Builder builder=new AlertDialog.Builder(this);
        builder.setTitle("Delete this task?");
        builder.setMessage("Do you really want to delete all completed tasks?");
        builder.setPositiveButton("Delete All", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                if(taskDBHelper.removeCompletedTasks()){
                    startActivity(new Intent(CompletedTasks.this,CompletedTasks.class));
                    Toast.makeText(CompletedTasks.this, "All Completed tasks deleted successfully!", Toast.LENGTH_SHORT).show();
                }
            }
        }).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                Toast.makeText(CompletedTasks.this, "Tasks not deleted!", Toast.LENGTH_SHORT).show();
            }
        }).create().show();
    }
}
