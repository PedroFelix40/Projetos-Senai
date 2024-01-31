import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { useFonts, Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';
import { ContainerApp } from './style';
import { Header } from './src/Components/Header';


export default function App() {
  let [fontsLoaded, fontError] = useFonts({
    Roboto_500Medium,
    Roboto_700Bold
  });

  if (!fontsLoaded && !fontError) {
    return null;
  }

  return (
    <ContainerApp>
      <StatusBar style="auto" />

    <Header/>


    </ContainerApp>
  );
}

