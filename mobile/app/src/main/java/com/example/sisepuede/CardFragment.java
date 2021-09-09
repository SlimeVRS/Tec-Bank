package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.example.sisepuede.databinding.FragmentCardBinding;
import com.example.sisepuede.databinding.FragmentLoanBinding;
import com.google.android.material.snackbar.Snackbar;


public class CardFragment extends Fragment {
    private FragmentCardBinding binding;




    public CardFragment() {
        // Required empty public constructor
    }


    public static CardFragment newInstance(String param1, String param2) {
        CardFragment fragment = new CardFragment();

        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentCardBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        binding.accBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(CardFragment.this).
                        navigate(R.id.action_cardFragment_to_accFragment);
            }
        });
        binding.exitBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(CardFragment.this).
                        navigate(R.id.action_cardFragment_to_logginFragment);
            }
        });
        binding.loanBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(CardFragment.this).
                        navigate(R.id.action_cardFragment_to_loanFragment);
            }
        });
        binding.buyListBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText tarjeta = (EditText) getActivity().findViewById(R.id.card_num_text);
                if(tarjeta.getText().toString().isEmpty()){
                    Snackbar.make(view, "Ingrese un numero de tarjeta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
                else{
                    if(tarjeta.getText().toString().equals("123") || tarjeta.getText().toString().equals("987")){
                    sendCard();
                    NavHostFragment.findNavController(CardFragment.this).
                            navigate(R.id.action_cardFragment_to_BuyListFrag);
                    }
                    else{
                        Snackbar.make(view, "Esta tarjeta no tiene movimientos", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }
                }


            }
        });

    }

    private void sendCard(){
        //Envio del usuario al fragmento de cuentas
        Bundle bundle= new Bundle();
        EditText card = (EditText) getActivity().findViewById(R.id.card_num_text);
        bundle.putString("card_num",card.getText().toString());
        getParentFragmentManager().setFragmentResult("card_Key", bundle);
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}