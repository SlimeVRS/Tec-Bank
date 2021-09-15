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
    private String cant;
    private String card;

    public static CardFragment newInstance(String param1, String param2) {
        CardFragment fragment = new CardFragment();

        return fragment;
    }

    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentCardBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.payCardBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText cantidad=(EditText) getActivity().findViewById(R.id.card_pay_amount_text);
                EditText tarjeta=(EditText) getActivity().findViewById(R.id.card_num_text);
                cant= cantidad.getText().toString();
                card= tarjeta.getText().toString();
                if (card.isEmpty()){
                    Snackbar.make(view, "Debe ingresar la tarjeta ", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                    return;

                }
                if(card.equals("123")){
                    if(cant.isEmpty()){
                        Snackbar.make(view, "Debe ingresar el monto a pagar", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                        return;

                    }
                    else {
                        Snackbar.make(view, "Se realizo el pago de: "+cant+
                                "\n a la tarjeta: "+card, Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                        return;
                    }
                }
                if(card.equals("456")){
                        Snackbar.make(view, "Esta tarjeta no tiene pagos pendientes", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    return;
                }
                else{
                    Snackbar.make(view, "No se encontro la tarjeta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                    return;

                }

            }
        });
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
                return;
            }
        });
        binding.loanBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(CardFragment.this).
                        navigate(R.id.action_cardFragment_to_loanFragment);
                return;
            }
        });
        binding.buyListBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText tarjeta = (EditText) getActivity().findViewById(R.id.card_num_text);
                if(tarjeta.getText().toString().isEmpty()){
                    Snackbar.make(view, "Ingrese un numero de tarjeta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                    return;
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
                        return;
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