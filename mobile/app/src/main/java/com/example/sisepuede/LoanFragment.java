package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.example.sisepuede.databinding.FragmentLoanBinding;
import com.google.android.material.snackbar.Snackbar;

public class LoanFragment extends Fragment {
    private FragmentLoanBinding binding;
    private String cant;
    private String loan;




    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentLoanBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.ordBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {                EditText prestamo=(EditText) getActivity().findViewById(R.id.loan_number_text);
                EditText cantidad=(EditText) getActivity().findViewById(R.id.pay_amount_text);
                loan=prestamo.getText().toString();
                cant=cantidad.getText().toString();
                if (loan.equals("") ){
                    Snackbar.make(view, "Debe ingresar la cuenta ", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();

                }
                if(loan.equals("456")){
                    if(cant.isEmpty()){
                        Snackbar.make(view, "Debe ingresar el monto", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }
                    else {
                        Snackbar.make(view, "Esta cuenta esta al dia", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }
                }
                if(loan.equals("123")){
                    if(cant.isEmpty()){
                        Snackbar.make(view, "Debe ingresar el monto", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }
                    else{
                        Snackbar.make(view, "Se realizó el pago ordinario de: "+cant+
                                "\n A la cuenta: "+loan, Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }
                }
                if(!(loan.equals("123") || loan.equals("456"))){
                    Snackbar.make(view, "La cuenta no existe ", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }

            }
        });
        binding.extraBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText prestamo=(EditText) getActivity().findViewById(R.id.loan_number_text);
                EditText cantidad=(EditText) getActivity().findViewById(R.id.pay_amount_text);
                loan=prestamo.getText().toString();
                cant=cantidad.getText().toString();
                if (loan.isEmpty() || cant.isEmpty()){
                    Snackbar.make(view, "Debe ingresar la cuenta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
                if(loan.equals("123") || loan.equals("456")){
                    if(cant.isEmpty()){
                        Snackbar.make(view, "Debe ingresar el monto", Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();

                    }
                    else{
                        Snackbar.make(view, "Se realizó el pago extra ordinario de: "+cant+
                                "\n A la cuenta: "+loan, Snackbar.LENGTH_LONG)
                                .setAction("Action", null).show();
                    }

                }
                else{
                    Snackbar.make(view, "El prestamo ingresado no existe", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
            }
        });
        binding.accBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(LoanFragment.this).
                        navigate(R.id.action_LoanFragment_to_accFragment);
            }
        });
        binding.exitBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(LoanFragment.this).
                        navigate(R.id.action_LoanFragment_to_logginFragment);
            }
        });
        binding.cardBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(LoanFragment.this).
                        navigate(R.id.action_LoanFragment_to_cardFragment);
            }
        });


    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}