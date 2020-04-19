package com.example.taskmanager.models;

public class PendingTaskModel {
    private int taskID;
    private String taskTitle,taskContent,taskDate,
            taskTime,taskTag;

    public PendingTaskModel(){}

    public PendingTaskModel(String taskTitle, String taskContent,String taskTag, String taskDate, String taskTime) {
        this.taskTitle = taskTitle;
        this.taskContent = taskContent;
        this.taskDate = taskDate;
        this.taskTime = taskTime;
        this.taskTag = taskTag;
    }

    public PendingTaskModel(int taskID, String taskTitle, String taskContent,String taskTag, String taskDate, String taskTime) {
        this.taskID = taskID;
        this.taskTitle = taskTitle;
        this.taskContent = taskContent;
        this.taskDate = taskDate;
        this.taskTime = taskTime;
        this.taskTag = taskTag;
    }

    public int getTaskID() {
        return taskID;
    }

    public void setTaskID(int taskID) {
        this.taskID = taskID;
    }

    public String getTaskTitle() {
        return taskTitle;
    }

    public void setTaskTitle(String taskTitle) {
        this.taskTitle = taskTitle;
    }

    public String getTaskContent() {
        return taskContent;
    }

    public void setTaskContent(String taskContent) {
        this.taskContent = taskContent;
    }

    public String getTaskDate() {
        return taskDate;
    }

    public void setTaskDate(String taskDate) {
        this.taskDate = taskDate;
    }

    public String getTaskTime() {
        return taskTime;
    }

    public void setTaskTime(String taskTime) {
        this.taskTime = taskTime;
    }

    public String getTaskTag() {
        return taskTag;
    }

    public void setTaskTag(String taskTag) {
        this.taskTag = taskTag;
    }
}
