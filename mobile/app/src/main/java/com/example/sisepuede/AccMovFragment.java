package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.example.sisepuede.databinding.FragmentAccBinding;
import com.example.sisepuede.databinding.FragmentAccMovBinding;

import java.util.ArrayList;
import java.util.List;


public class AccMovFragment extends Fragment {
    private FragmentAccMovBinding binding;
    private ListView list;
    private List<String> datos = new ArrayList<>();
    private ArrayAdapter<String> adapter;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentAccMovBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        list=getActivity().findViewById(R.id.lista_mov);
        cargarLista();
        adapter= new ArrayAdapter<>(getActivity(), android.R.layout.simple_list_item_1,datos);
        list.setAdapter(adapter);

    }
    private void cargarLista(){
        addText("Cuenta      Monto");
        addText("23442      -1500");
        addText("5839       -1000");
        addText("345        +10000");
        addText("567        +3000");
    }
    private void addText(String text){
        datos.add(text);
    }
}

