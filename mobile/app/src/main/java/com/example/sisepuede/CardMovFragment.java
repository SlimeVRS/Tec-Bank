package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentResultListener;



import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import android.widget.ListView;
import android.widget.TextView;

import com.example.sisepuede.databinding.FragmentCardMovBinding;
import com.google.android.material.snackbar.Snackbar;


import java.util.ArrayList;
import java.util.List;


public class CardMovFragment extends Fragment {
    private FragmentCardMovBinding binding;
    private ListView list;
    private List<String> datos = new ArrayList<>();
    private ArrayAdapter<String> adapter;
    private String cardNum;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {
        getParentFragmentManager().setFragmentResultListener("card_Key", getActivity(), new FragmentResultListener() {
            @Override
            public void onFragmentResult(@NonNull String key, @NonNull Bundle bundle) {
                cardNum = bundle.getString("card_num");
            }
        });
        binding = FragmentCardMovBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        list=getActivity().findViewById(R.id.listaa);

        binding.showBuys.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                System.out.println(cardNum);
                if (cardNum.equals("123")){
                    card_1();
                    adapter=new ArrayAdapter<>(getActivity(), android.R.layout.simple_list_item_1,datos);
                    list.setAdapter(adapter);
                    return;

                }
                if (cardNum.equals("987")){
                    card_2();adapter=new ArrayAdapter<>(getActivity(), android.R.layout.simple_list_item_1,datos);
                    list.setAdapter(adapter);
                    return;

                }
                else{
                    addText("No hay movimientos");

                }

            }
        });



    }

    public View getView(int position, View convertView, ViewGroup container) {
        if (convertView == null) {
            convertView = getLayoutInflater().inflate(R.layout.fragment_card_mov, container, false);
        }

        ((TextView) convertView.findViewById(android.R.id.list))
                .setText("hello");
        return convertView;
    }
    //Funcion que carga los datos de la tarjeta 1
    private void card_1(){
        addText("Pago Carro -150000");
        addText("Pago Agua  -10000");
        addText("walmart    -100000");
        addText("SINPE      +30000");
    }
    //Funcion que carga los datos de la tarjeta 2
    private void card_2(){
        addText("Telecable  -35000");
        addText("Claro      -12000");
        addText("SINPE      +30000");
    }
    //Funcion que agrega datos al array que se mostrara en pantalla
    private void addText(String text){
        datos.add(text);
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}