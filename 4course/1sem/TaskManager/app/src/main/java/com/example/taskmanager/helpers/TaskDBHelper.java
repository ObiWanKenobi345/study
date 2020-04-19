package com.example.taskmanager.helpers;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import com.example.taskmanager.models.CompletedTaskModel;
import com.example.taskmanager.models.PendingTaskModel;

import java.util.ArrayList;

public class TaskDBHelper {
    private Context context;
    private DatabaseHelper databaseHelper;

    public TaskDBHelper(Context context){
        this.context=context;
        databaseHelper=new DatabaseHelper(context);
    }

    //add new tasks into the database
    public boolean addNewTask(PendingTaskModel pendingTaskModel){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put(DatabaseHelper.COL_TASK_TITLE,pendingTaskModel.getTaskTitle());
        contentValues.put(DatabaseHelper.COL_TASK_CONTENT,pendingTaskModel.getTaskContent());
        contentValues.put(DatabaseHelper.COL_TASK_TAG,pendingTaskModel.getTaskTag());
        contentValues.put(DatabaseHelper.COL_TASK_DATE,pendingTaskModel.getTaskDate());
        contentValues.put(DatabaseHelper.COL_TASK_TIME,pendingTaskModel.getTaskTime());
        contentValues.put(DatabaseHelper.COL_TASK_STATUS,DatabaseHelper.COL_DEFAULT_STATUS);
        sqLiteDatabase.insert(DatabaseHelper.TABLE_TASK_NAME,null,contentValues);
        sqLiteDatabase.close();
        return true;
    }

    //count tasks from the database
    public int countTasks(){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String count="SELECT " + DatabaseHelper.COL_TASK_ID + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_STATUS+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(count,new String[]{DatabaseHelper.COL_DEFAULT_STATUS});
        return cursor.getCount();
    }

    //count completed tasks from the database
    public int countCompletedTasks(){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String count="SELECT " + DatabaseHelper.COL_TASK_ID + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_STATUS+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(count,new String[]{DatabaseHelper.COL_STATUS_COMPLETED});
        return cursor.getCount();
    }

    //fetch all the tasks from the database
    public ArrayList<PendingTaskModel> fetchAllTasks(){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        ArrayList<PendingTaskModel> pendingTaskModels=new ArrayList<>();
        String query="SELECT * FROM " + DatabaseHelper.TABLE_TASK_NAME+" INNER JOIN " + DatabaseHelper.TABLE_TAG_NAME+" ON " + DatabaseHelper.TABLE_TASK_NAME+"."+DatabaseHelper.COL_TASK_TAG+"="+
                DatabaseHelper.TABLE_TAG_NAME+"."+DatabaseHelper.COL_TAG_ID + " WHERE " + DatabaseHelper.COL_TASK_STATUS+"=? ORDER BY " + DatabaseHelper.TABLE_TASK_NAME+"."+DatabaseHelper.COL_TASK_ID + " ASC";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{DatabaseHelper.COL_DEFAULT_STATUS});
        while (cursor.moveToNext()){
            PendingTaskModel pendingTaskModel=new PendingTaskModel();
            pendingTaskModel.setTaskID(cursor.getInt(cursor.getColumnIndex(DatabaseHelper.COL_TASK_ID)));
            pendingTaskModel.setTaskTitle(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TITLE)));
            pendingTaskModel.setTaskContent(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_CONTENT)));
            pendingTaskModel.setTaskTag(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TAG_TITLE)));
            pendingTaskModel.setTaskDate(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_DATE)));
            pendingTaskModel.setTaskTime(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TIME)));
            pendingTaskModels.add(pendingTaskModel);
        }
        cursor.close();
        sqLiteDatabase.close();
        return pendingTaskModels;
    }



    //fetch all the completed tasks from the database
    public ArrayList<CompletedTaskModel> fetchCompletedTasks(){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        ArrayList<CompletedTaskModel> completedTaskModels=new ArrayList<>();
        String query="SELECT * FROM " + DatabaseHelper.TABLE_TASK_NAME+" INNER JOIN " + DatabaseHelper.TABLE_TAG_NAME+" ON " + DatabaseHelper.TABLE_TASK_NAME+"."+DatabaseHelper.COL_TASK_TAG+"="+
                DatabaseHelper.TABLE_TAG_NAME+"."+DatabaseHelper.COL_TAG_ID + " WHERE " + DatabaseHelper.COL_TASK_STATUS+"=? ORDER BY " + DatabaseHelper.TABLE_TASK_NAME+"."+DatabaseHelper.COL_TASK_ID + " DESC";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{DatabaseHelper.COL_STATUS_COMPLETED});
        while (cursor.moveToNext()){
            CompletedTaskModel completedTaskModel=new CompletedTaskModel();
            completedTaskModel.setTaskID(cursor.getInt(cursor.getColumnIndex(DatabaseHelper.COL_TASK_ID)));
            completedTaskModel.setTaskTitle(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TITLE)));
            completedTaskModel.setTaskContent(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_CONTENT)));
            completedTaskModel.setTaskTag(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TAG_TITLE)));
            completedTaskModel.setTaskDate(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_DATE)));
            completedTaskModel.setTaskTime(cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TIME)));
            completedTaskModels.add(completedTaskModel);
        }
        cursor.close();
        sqLiteDatabase.close();
        return completedTaskModels;
    }

    //update tasks according to the tasks id
    public boolean updateTask(PendingTaskModel pendingTaskModel){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put(DatabaseHelper.COL_TASK_TITLE,pendingTaskModel.getTaskTitle());
        contentValues.put(DatabaseHelper.COL_TASK_CONTENT,pendingTaskModel.getTaskContent());
        contentValues.put(DatabaseHelper.COL_TASK_TAG,pendingTaskModel.getTaskTag());
        contentValues.put(DatabaseHelper.COL_TASK_DATE,pendingTaskModel.getTaskDate());
        contentValues.put(DatabaseHelper.COL_TASK_TIME,pendingTaskModel.getTaskTime());
        contentValues.put(DatabaseHelper.COL_TASK_STATUS,DatabaseHelper.COL_DEFAULT_STATUS);
        sqLiteDatabase.update(DatabaseHelper.TABLE_TASK_NAME,contentValues,DatabaseHelper.COL_TASK_ID+"=?",new String[]{String.valueOf(pendingTaskModel.getTaskID())});
        sqLiteDatabase.close();
        return true;
    }

    //make tasks completed according to the id
    public boolean makeCompleted(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put(DatabaseHelper.COL_TASK_STATUS,DatabaseHelper.COL_STATUS_COMPLETED);
        sqLiteDatabase.update(DatabaseHelper.TABLE_TASK_NAME,contentValues,DatabaseHelper.COL_TASK_ID+"=?",
                new String[]{String.valueOf(taskID)});
        sqLiteDatabase.close();
        return true;
    }

    //remove tasks according to the tasks id
    public boolean removeTask(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        sqLiteDatabase.delete(DatabaseHelper.TABLE_TASK_NAME,DatabaseHelper.COL_TASK_ID+"=?",new String[]{String.valueOf(taskID)});
        sqLiteDatabase.close();
        return true;
    }

    //remove all the completed tasks
    public boolean removeCompletedTasks(){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        sqLiteDatabase.delete(DatabaseHelper.TABLE_TASK_NAME,DatabaseHelper.COL_TASK_STATUS+"=?",new String[]{DatabaseHelper.COL_STATUS_COMPLETED});
        sqLiteDatabase.close();
        return true;
    }

    //fetch tasks title from the database according the tasks id
    public String fetchTaskTitle(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String query="SELECT " + DatabaseHelper.COL_TASK_TITLE + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_ID+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{String.valueOf(taskID)});
        String title="";
        if(cursor.moveToFirst()){
            title=cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TITLE));
        }
        cursor.close();
        sqLiteDatabase.close();
        return title;
    }

    //fetch tasks content from the database according the tasks id
    public String fetchTaskContent(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String query="SELECT " + DatabaseHelper.COL_TASK_CONTENT + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_ID+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{String.valueOf(taskID)});
        String content="";
        if(cursor.moveToFirst()){
            content=cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_CONTENT));
        }
        cursor.close();
        sqLiteDatabase.close();
        return content;
    }

    //fetch tasks date from the database according the tasks id
    public String fetchTaskDate(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String query="SELECT " + DatabaseHelper.COL_TASK_DATE + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_ID+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{String.valueOf(taskID)});
        String date="";
        if(cursor.moveToFirst()){
            date=cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_DATE));
        }
        cursor.close();
        sqLiteDatabase.close();
        return date;
    }

    //fetch tasks time from the database according the tasks id
    public String fetchTaskTime(int taskID){
        SQLiteDatabase sqLiteDatabase=this.databaseHelper.getReadableDatabase();
        String query="SELECT " + DatabaseHelper.COL_TASK_TIME + " FROM " + DatabaseHelper.TABLE_TASK_NAME + " WHERE " + DatabaseHelper.COL_TASK_ID+"=?";
        Cursor cursor=sqLiteDatabase.rawQuery(query,new String[]{String.valueOf(taskID)});
        String time="";
        if(cursor.moveToFirst()){
            time=cursor.getString(cursor.getColumnIndex(DatabaseHelper.COL_TASK_TIME));
        }
        cursor.close();
        sqLiteDatabase.close();
        return time;
    }
}
