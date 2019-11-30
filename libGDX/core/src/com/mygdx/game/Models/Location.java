package com.mygdx.game.Models;

public class Location {


    private double latitude,longtitude;
    public Location(double latitude,double longtitude){
        this.latitude = latitude;
        this.longtitude = longtitude;
    }

    public double getLatitude() {
        return latitude;
    }

    public double getLongtitude() {
        return longtitude;
    }

}
