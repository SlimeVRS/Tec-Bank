package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
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

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {
        binding = FragmentCardMovBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        list=getActivity().findViewById(R.id.listaa);

        addText("hola");
        addText("como");
        addText("estas");
        adapter=new ArrayAdapter<>(getActivity(), android.R.layout.simple_list_item_1,datos);
        list.setAdapter(adapter);



    }

    public View getView(int position, View convertView, ViewGroup container) {
        if (convertView == null) {
            convertView = getLayoutInflater().inflate(R.layout.fragment_card_mov, container, false);
        }

        ((TextView) convertView.findViewById(android.R.id.list))
                .setText("hello");
        return convertView;
    }

    private void addText(String text){
        datos.add(text);
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}