package com.mygdx.game;

import android.location.LocationListener;
import android.os.Bundle;

import com.badlogic.gdx.backends.android.AndroidApplication;
import com.badlogic.gdx.backends.android.AndroidApplicationConfiguration;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.tasks.OnSuccessListener;
import com.mygdx.game.Models.Location;
import com.mygdx.game.Modules.ISensor;
import com.mygdx.game.MyGdxGame;

public class AndroidLauncher extends AndroidApplication implements ISensor {

    private FusedLocationProviderClient fusedLocationClient;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidApplicationConfiguration config = new AndroidApplicationConfiguration();
        initialize(new MyGdxGame(this), config);
    }

    @Override
    public Location getLocation() {
        android.location.Location location = fusedLocationClient.getLastLocation().getResult();
        return new Location(location.getLatitude(),location.getLongitude());

    }
}

