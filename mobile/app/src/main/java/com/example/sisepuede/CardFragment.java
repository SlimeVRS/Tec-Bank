package com.example.sisepuede;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.sisepuede.databinding.FragmentCardBinding;
import com.example.sisepuede.databinding.FragmentLoanBinding;


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
                NavHostFragment.findNavController(CardFragment.this).
                        navigate(R.id.action_cardFragment_to_BuyListFrag);
            }
        });

    }



    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}