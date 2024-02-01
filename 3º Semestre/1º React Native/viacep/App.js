import { StatusBar } from 'expo-status-bar';
import { ContainerApp } from './style';


// Import da fonts
import { useFonts, Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';
import { Home } from './src/screens/Home';
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

    {/* HEADER */}
    <Header/>

    {/* HOMESCREEN */}
    <Home/>

    </ContainerApp>
  );
}

