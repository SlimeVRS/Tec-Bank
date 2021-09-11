package com.example.sisepuede;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentResultListener;
import androidx.navigation.fragment.NavHostFragment;

import com.example.sisepuede.databinding.FragmentAccBinding;
import com.google.android.material.snackbar.Snackbar;

public class AccountFragment extends Fragment {

    private FragmentAccBinding binding;
    private String user;
    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {
        getParentFragmentManager().setFragmentResultListener("log_Key", this, new FragmentResultListener() {
            @Override
            public void onFragmentResult(@NonNull String key, @NonNull Bundle bundle) {
                user = bundle.getString("user");

            }
        });
        EditText editText;
        binding = FragmentAccBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.movBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText cuenta = (EditText) getActivity().findViewById(R.id.acc_num_text);
                if (cuenta.getText().toString().isEmpty()) {
                    Snackbar.make(view, "Ingrese un numero de cuenta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }

                if (cuenta.getText().toString().equals("123") ) {
                    NavHostFragment.findNavController(AccountFragment.this)
                            .navigate(R.id.action_AccFragment_to_AccMovFragment);

                }
                if (cuenta.getText().toString().equals("135") ) {
                    Snackbar.make(view, "Esta cuenta no posee movimientos", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();

                }
                else {
                    Snackbar.make(view, "No se encontro esta cuenta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
            }
        });


        binding.tranferBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                EditText cuenta = (EditText) getActivity().findViewById(R.id.acc_num_text);
                if (cuenta.getText().toString().equals("123") || cuenta.getText().toString().equals("135") ){
                    NavHostFragment.findNavController(AccountFragment.this)
                            .navigate(R.id.action_AccFragment_to_TransferFragment);

                }
                else{
                    Snackbar.make(view, "No se encontro esta cuenta", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
            }
        });
        binding.exitBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(AccountFragment.this)
                        .navigate(R.id.action_AccFragment_to_logginFragment);
            }
        });
        binding.cardBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(AccountFragment.this)
                        .navigate(R.id.action_AccFragment_to_cardFragment);
            }
        });
        binding.loanBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment.findNavController(AccountFragment.this)
                        .navigate(R.id.action_AccFragment_to_loanFragment);
            }
        });

    }


    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}