package com.example.sisepuede;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.example.sisepuede.databinding.FragmentLogginBinding;

public class LogginFragment extends Fragment {

    private FragmentLogginBinding binding;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceStat
    ) {


        binding = FragmentLogginBinding.inflate(inflater, container, false);

        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.buttonFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //llamada a la función que verifica si es un usuario valido
                //if(iniciarSesion()){
                if(true){
                    send();
                    NavHostFragment.findNavController(LogginFragment.this)
                            .navigate(R.id.action_FirstFragment_to_AccFragment);
                }

            }

        });
    }
    private boolean iniciarSesion(){
        //obtención de los datos del usuario
        EditText user = (EditText) getActivity().findViewById(R.id.user_text);
        EditText password = (EditText) getActivity().findViewById(R.id.pass_text);
        System.out.println("");
        System.out.println(user.getText().toString() );
        System.out.println("asd");
        //System.out.println(password.getText() );
        //cambiar asd y 123 por el usuario y contrasena obtenida de
        if(user.getText().toString().equals("asd") && password.getText().toString().equals("123")){
            return true;
        }
        else{
            return false;
        }
    }

    private void send(){
        //Envio del usuario al fragmento de cuentas
        Bundle bundle= new Bundle();
        EditText user = (EditText) getActivity().findViewById(R.id.user_text);
        bundle.putString("user",user.getText().toString());
        getParentFragmentManager().setFragmentResult("log_Key", bundle);
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}