package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.example.sisepuede.databinding.FragmentTranferenciaBinding;
import com.google.android.material.snackbar.Snackbar;


public class TranferenciaFragment extends Fragment {
    private FragmentTranferenciaBinding binding;
    private String acc;
    private String cantidad;




    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentTranferenciaBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState){
        super.onViewCreated(view, savedInstanceState);

        binding.sendBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText cuenta = (EditText) getActivity().findViewById(R.id.num_cuenta_envio);
                EditText monto = (EditText) getActivity().findViewById(R.id.cant_text);
                cantidad=monto.getText().toString();

                acc=cuenta.getText().toString();
                if(acc.isEmpty()){
                    Snackbar.make(view, "Ingrese un numero de cuenta a la que desea depositar", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
                if(cantidad.isEmpty()){
                    Snackbar.make(view, "Ingrese la cantidad que desea depositar", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
                else{

                    Snackbar.make(view, "Se realizo el pago a de: "+ cantidad+ "\na la cuenta "+acc, Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }

            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}