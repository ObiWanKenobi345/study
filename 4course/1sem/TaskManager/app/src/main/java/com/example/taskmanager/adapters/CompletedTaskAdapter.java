package com.example.taskmanager.adapters;

import android.content.Context;
import android.graphics.Paint;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.taskmanager.R;
import com.example.taskmanager.helpers.SettingsHelper;
import com.example.taskmanager.helpers.TaskDBHelper;
import com.example.taskmanager.models.CompletedTaskModel;

import java.util.ArrayList;

public class CompletedTaskAdapter extends RecyclerView.Adapter<CompletedTaskAdapter.CompletedDataHolder>{
    private ArrayList<CompletedTaskModel> completedTaskModels;
    private Context context;
    private TaskDBHelper taskDBHelper;

    public CompletedTaskAdapter(ArrayList<CompletedTaskModel> completedTaskModels, Context context) {
        this.completedTaskModels = completedTaskModels;
        this.context = context;
    }

    @Override
    public CompletedTaskAdapter.CompletedDataHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view= LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_completed_task_layout,parent,false);
        return new CompletedDataHolder(view);
    }

    @Override
    public void onBindViewHolder(CompletedTaskAdapter.CompletedDataHolder holder, int position) {
        taskDBHelper=new TaskDBHelper(context);
        CompletedTaskModel completedTaskModel=completedTaskModels.get(position);
        holder.taskTitle.setPaintFlags(holder.taskTitle.getPaintFlags()| Paint.STRIKE_THRU_TEXT_FLAG);
        holder.taskTitle.setText(completedTaskModel.getTaskTitle());
        SettingsHelper.applyTextColor(holder.taskTitle,context);
        holder.taskContent.setText(completedTaskModel.getTaskContent());
        holder.taskTag.setText(completedTaskModel.getTaskTag());
        holder.taskDate.setText(completedTaskModel.getTaskDate());
        holder.taskTime.setText(completedTaskModel.getTaskTime());
    }

    @Override
    public int getItemCount() {
        return completedTaskModels.size();
    }

    public class CompletedDataHolder extends RecyclerView.ViewHolder {
        TextView taskTitle,taskContent,taskTag,taskDate,taskTime;
        public CompletedDataHolder(View itemView) {
            super(itemView);
            taskTitle=(TextView)itemView.findViewById(R.id.completed_task_title);
            taskContent=(TextView)itemView.findViewById(R.id.completed_task_content);
            taskTag=(TextView)itemView.findViewById(R.id.task_tag);
            taskDate=(TextView)itemView.findViewById(R.id.task_date);
            taskTime=(TextView)itemView.findViewById(R.id.task_time);
        }
    }

    //filter the search
    public void filterCompletedTasks(ArrayList<CompletedTaskModel> newCompletedTaskModels){
        completedTaskModels=new ArrayList<>();
        completedTaskModels.addAll(newCompletedTaskModels);
        notifyDataSetChanged();
    }
}
