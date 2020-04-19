package com.example.taskmanager.adapters;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.design.widget.TextInputEditText;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.PopupMenu;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.example.taskmanager.R;
import com.example.taskmanager.activities.CompletedTasks;
import com.example.taskmanager.activities.MainActivity;
import com.example.taskmanager.helpers.SettingsHelper;
import com.example.taskmanager.helpers.TagDBHelper;
import com.example.taskmanager.helpers.TaskDBHelper;
import com.example.taskmanager.models.PendingTaskModel;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Calendar;

public class PendingTaskAdapter extends RecyclerView.Adapter<PendingTaskAdapter.PendingDataHolder>{
    private ArrayList<PendingTaskModel> pendingTaskModels;
    private Context context;
    private String getTagTitleString;
    private TagDBHelper tagDBHelper;
    private TaskDBHelper taskDBHelper;

    public PendingTaskAdapter(ArrayList<PendingTaskModel> pendingTaskModels, Context context) {
        this.pendingTaskModels = pendingTaskModels;
        this.context = context;
    }

    @Override
    public PendingTaskAdapter.PendingDataHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view= LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_pending_task_layout,parent,false);
        return new PendingDataHolder(view);
    }

    @Override
    public void onBindViewHolder(PendingTaskAdapter.PendingDataHolder holder, int position) {
        taskDBHelper=new TaskDBHelper(context);
        final PendingTaskModel pendingTaskModel=pendingTaskModels.get(position);
        holder.taskTitle.setText(pendingTaskModel.getTaskTitle());
        holder.taskContent.setText(pendingTaskModel.getTaskContent());
        holder.taskDate.setText(pendingTaskModel.getTaskDate());
        holder.taskTag.setText(pendingTaskModel.getTaskTag());
        holder.taskTime.setText(pendingTaskModel.getTaskTime());
        holder.option.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                PopupMenu popupMenu=new PopupMenu(context,view);
                popupMenu.getMenuInflater().inflate(R.menu.task_edit_del_options,popupMenu.getMenu());
                popupMenu.show();
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                    @Override
                    public boolean onMenuItemClick(MenuItem menuItem) {
                        switch (menuItem.getItemId()){
                            case R.id.edit:
                                showDialogEdit(pendingTaskModel.getTaskID());
                                return true;
                            case R.id.delete:
                                showDeleteDialog(pendingTaskModel.getTaskID());
                                return true;
                            default:
                                return false;
                        }
                    }
                });
            }
        });
        holder.makeCompleted.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                showCompletedDialog(pendingTaskModel.getTaskID());
            }
        });
    }

    //showing confirmation dialog for deleting the tasks
    private void showDeleteDialog(final int tagID){
        AlertDialog.Builder builder=new AlertDialog.Builder(context);
        builder.setTitle("Delete this task?");
        builder.setMessage("Do you really want to delete it?");
        builder.setPositiveButton("Delete", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                if(taskDBHelper.removeTask(tagID)){
                    Toast.makeText(context, "Task deleted successfully!", Toast.LENGTH_SHORT).show();
                    context.startActivity(new Intent(context, MainActivity.class));
                }
            }
        }).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                Toast.makeText(context, "Task not deleted!", Toast.LENGTH_SHORT).show();
                context.startActivity(new Intent(context, MainActivity.class));
            }
        }).create().show();
    }

    @Override
    public int getItemCount() {
        return pendingTaskModels.size();
    }

    //showing edit dialog for editing tasks according to the taskid
    private void showDialogEdit(final int taskID){
        taskDBHelper=new TaskDBHelper(context);
        tagDBHelper=new TagDBHelper(context);
        final AlertDialog.Builder builder=new AlertDialog.Builder(context);
        LayoutInflater layoutInflater=(LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        final View view=layoutInflater.inflate(R.layout.edit_task_dialog,null);
        builder.setView(view);
        SettingsHelper.applyThemeTextView((TextView)view.findViewById(R.id.edit_task_dialog_title),context);
        final TextInputEditText taskTitle=(TextInputEditText)view.findViewById(R.id.task_title);
        final TextInputEditText taskContent=(TextInputEditText)view.findViewById(R.id.task_content);
        Spinner taskTags=(Spinner)view.findViewById(R.id.task_tag);
        //stores all the tags title in string format
        ArrayAdapter<String> tagsModelArrayAdapter=new ArrayAdapter<String>(context,android.R.layout.simple_spinner_dropdown_item,tagDBHelper.fetchTagStrings());
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

        //setting the default values coming from the database
        taskTitle.setText(taskDBHelper.fetchTaskTitle(taskID));
        taskContent.setText(taskDBHelper.fetchTaskContent(taskID));
        taskDate.setText(taskDBHelper.fetchTaskDate(taskID));
        taskTime.setText(taskDBHelper.fetchTaskTime(taskID));

        //getting current calendar credentials
        final Calendar calendar=Calendar.getInstance();
        final int year=calendar.get(Calendar.YEAR);
        final int month=calendar.get(Calendar.MONTH);
        final int day=calendar.get(Calendar.DAY_OF_MONTH);
        final int hour=calendar.get(Calendar.HOUR);
        final int minute=calendar.get(Calendar.MINUTE);

        //getting the taskdate
        taskDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatePickerDialog datePickerDialog=new DatePickerDialog(context, new DatePickerDialog.OnDateSetListener() {
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
                TimePickerDialog timePickerDialog=new TimePickerDialog(context, new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker timePicker, int i, int i1) {
                        Calendar newCalendar=Calendar.getInstance();
                        newCalendar.set(Calendar.HOUR,i);
                        newCalendar.set(Calendar.MINUTE,i1);
                        String timeFormat= DateFormat.getTimeInstance(DateFormat.SHORT).format(newCalendar.getTime());
                        taskTime.setText(timeFormat);
                    }
                },hour,minute,false);
                timePickerDialog.show();
            }
        });
        TextView cancel=(TextView)view.findViewById(R.id.cancel);
        TextView addTask=(TextView)view.findViewById(R.id.add_new_task);
        SettingsHelper.applyTextColor(cancel,context);
        SettingsHelper.applyTextColor(addTask,context);
        addTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //getting all the values from add new tasks dialog
                String getTaskTitle=taskTitle.getText().toString();
                String getTaskContent=taskContent.getText().toString();
                int taskTagID=tagDBHelper.fetchTagID(getTagTitleString);
                String getTaskDate=taskDate.getText().toString();
                String getTime=taskTime.getText().toString();

                //checking the data files
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
                }else if(taskDBHelper.updateTask(
                        new PendingTaskModel(taskID,getTaskTitle,getTaskContent,String.valueOf(taskTagID),getTaskDate,getTime)
                )){
                    Toast.makeText(context, R.string.task_title_add_success_msg, Toast.LENGTH_SHORT).show();
                    context.startActivity(new Intent(context,MainActivity.class));
                }
            }
        });
        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                context.startActivity(new Intent(context,MainActivity.class));
            }
        });
        builder.create().show();
    }

    //showing confirmation dialog for making the task completed
    private void showCompletedDialog(final int tagID){
        AlertDialog.Builder builder=new AlertDialog.Builder(context);
        builder.setTitle("Completed?");
        builder.setMessage("Did you complete this task?");
        builder.setPositiveButton("Completed", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                if(taskDBHelper.makeCompleted(tagID)){
                    context.startActivity(new Intent(context, CompletedTasks.class));
                }
            }
        }).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {

            }
        }).create().show();
    }

    public class PendingDataHolder extends RecyclerView.ViewHolder {
        TextView taskTitle,taskContent,taskTag,taskDate,taskTime;
        ImageView option,makeCompleted;
        public PendingDataHolder(View itemView) {
            super(itemView);
            taskTitle=(TextView)itemView.findViewById(R.id.pending_task_title);
            taskContent=(TextView)itemView.findViewById(R.id.pending_task_content);
            taskTag=(TextView)itemView.findViewById(R.id.task_tag);
            taskDate=(TextView)itemView.findViewById(R.id.task_date);
            taskTime=(TextView)itemView.findViewById(R.id.task_time);
            option=(ImageView)itemView.findViewById(R.id.option);
            makeCompleted=(ImageView)itemView.findViewById(R.id.make_completed);
        }
    }

    //filter the search
    public void filterTasks(ArrayList<PendingTaskModel> newPendingTaskModels){
        pendingTaskModels=new ArrayList<>();
        pendingTaskModels.addAll(newPendingTaskModels);
        notifyDataSetChanged();
    }
}
