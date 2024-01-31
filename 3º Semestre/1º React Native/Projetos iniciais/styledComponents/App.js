import { StatusBar } from 'expo-status-bar';
import { useEffect, useState } from 'react';
import { SafeAreaView, StyleSheet, Text, TouchableOpacity, View } from 'react-native';

// Import dos components
import { Container } from './src/components/Container/Container';
import { Title } from './src/components/Title/Title';
import { Box } from './src/components/Box/Box';
import { BoxButton } from './src/components/Box/BoxButton';
import { BtnIncrement } from './src/components/Button/BtnIncrement';
import { BtnDecrement } from './src/components/Button/BtnDecrement';
import { TitleBntDecrement } from './src/components/Title/TitleBntDecrement';

import { useFonts, PTSans_700Bold } from '@expo-google-fonts/pt-sans';

export default function App() {
  // let [fontsLoaded, fontError] = useFonts({
  //   PTSans_700Bold,
  // });

  // if (!fontsLoaded && !fontError) {
  //   return null;
  // }

  // Hook state
  const [count, setCount] = useState(0)

  // função para incrementar

  const increment = () => {
    setCount(count + 1)
  }
  const decremento = () => {
    if (count > 0) {setCount(count - 1)}
  }

  useEffect(() => {
    console.warn(`Contador atualizado: ${count}`)
  }, [count])

  return (
    // <SafeAreaView>
      <Container>
        <Box>

          {/* Title */}
          <Title>{count}</Title>

          <BoxButton>

            {/* BtnIncrement */}
            <BtnIncrement
              onPress={increment}
            >
              {/* TitleBntIncrement */}
              <TitleBntDecrement >Aumentar</TitleBntDecrement>
            </BtnIncrement>
            
            {/* BtnDecrement */}
            <BtnDecrement
              onPress={decremento}
            >
              {/* TitleBntDecrement */}
              <TitleBntDecrement >Diminuir</TitleBntDecrement>
            </BtnDecrement>
          </BoxButton>
        </Box>

        <StatusBar style="auto" />
      </Container>
   // </SafeAreaView>
  );
}

