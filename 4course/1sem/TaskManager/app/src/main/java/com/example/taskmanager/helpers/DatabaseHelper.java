package com.example.taskmanager.helpers;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;


public class DatabaseHelper extends SQLiteOpenHelper {
    private static final int DATABASE_VERSION=1;
    private static final String DATABASE_NAME="taskmanager";

    //tag table and columns
    public static final String TABLE_TAG_NAME="tags";
    public static final String COL_TAG_ID="tag_id";
    public static final String COL_TAG_TITLE="tag_title";

    //tasks table and columns
    public static final String TABLE_TASK_NAME="tasks";
    public static final String COL_TASK_ID="task_id";
    public static final String COL_TASK_TITLE="task_title";
    public static final String COL_TASK_CONTENT="task_content";
    public static final String COL_TASK_TAG="task_tag";
    public static final String COL_TASK_DATE="task_date";
    public static final String COL_TASK_TIME="task_time";
    public static final String COL_TASK_STATUS="task_status";
    public static final String COL_DEFAULT_STATUS="pending";
    public static final String COL_STATUS_COMPLETED="completed";

    //foreign key
    public static final String FORCE_FOREIGN_KEY="PRAGMA foreign_keys=ON";

    //tags table query
    private static final String CREATE_TAGS_TABLE="CREATE TABLE IF NOT EXISTS " + TABLE_TAG_NAME+"("+
            COL_TAG_ID+" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"+
            COL_TAG_TITLE+" TEXT NOT NULL UNIQUE"+")";

    //creating tasks table query
    private static final String CREATE_TASKS_TABLE="CREATE TABLE IF NOT EXISTS " + TABLE_TASK_NAME+"("+
            COL_TASK_ID+" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"+
            COL_TASK_TITLE+" TEXT NOT NULL,"+COL_TASK_CONTENT+" TEXT NOT NULL,"+
            COL_TASK_TAG +" INTEGER NOT NULL,"+COL_TASK_DATE+" TEXT NOT NULL,"+
            COL_TASK_TIME+" TEXT NOT NULL,"+COL_TASK_STATUS+" TEXT NOT NULL DEFAULT " + COL_DEFAULT_STATUS+
            ",FOREIGN KEY("+COL_TASK_TAG+") REFERENCES "+TABLE_TAG_NAME+"("+COL_TAG_ID+") ON UPDATE CASCADE ON DELETE CASCADE"+")";

    //dropping tags table
    private static final String DROP_TAGS_TABLE="DROP TABLE IF EXISTS " + TABLE_TAG_NAME;
    //dropping tasks table
    private static final String DROP_TASKS_TABLE="DROP TABLE IF EXISTS " + TABLE_TASK_NAME;


    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL(CREATE_TAGS_TABLE);
        sqLiteDatabase.execSQL(CREATE_TASKS_TABLE);
        sqLiteDatabase.execSQL(FORCE_FOREIGN_KEY);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL(DROP_TAGS_TABLE);
        sqLiteDatabase.execSQL(DROP_TASKS_TABLE);
        onCreate(sqLiteDatabase);
    }
}
