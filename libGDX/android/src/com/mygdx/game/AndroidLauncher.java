package com.mygdx.game;

import android.location.LocationListener;
import android.os.Bundle;

import com.badlogic.gdx.backends.android.AndroidApplication;
import com.badlogic.gdx.backends.android.AndroidApplicationConfiguration;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationCallback;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationResult;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.OnSuccessListener;
import com.mygdx.game.Models.Location;
import com.mygdx.game.Modules.ISensor;
import com.mygdx.game.MyGdxGame;

public class AndroidLauncher extends AndroidApplication implements ISensor {

    private FusedLocationProviderClient mFusedLocationClient;
    private LocationRequest mLocationRequest;
    private android.location.Location location2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //set up libGDX
        super.onCreate(savedInstanceState);
        AndroidApplicationConfiguration config = new AndroidApplicationConfiguration();
        initialize(new MyGdxGame(this), config);

        //set up GPS listener
        mLocationRequest = LocationRequest.create()
                .setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY)
                .setInterval(60000) ;     // 10 seconds, in milliseconds

        if(mFusedLocationClient == null) {
            mFusedLocationClient = LocationServices.getFusedLocationProviderClient(this);
            mFusedLocationClient.requestLocationUpdates(mLocationRequest,
                    locationCallback,
                    null /* Looper */);
        }
    }
    private LocationCallback locationCallback = new LocationCallback() {
        @Override
        public void onLocationResult(LocationResult locationResult) {
            super.onLocationResult(locationResult);
            android.location.Location location = locationResult.getLastLocation();
            if (location != null) {
                location2 = location;
            }
        }
    };

    @Override
    public Location getLocation() {
        if(location2 == null){
            return new Location(0,0);
        }
        return new Location(location2.getLatitude(),location2.getLongitude());

    }
}

