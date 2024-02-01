import { StatusBar } from 'expo-status-bar';
import { ContainerApp } from './style';
import { Header } from './src/Components/Header';

// Import da fonts
import { useFonts, Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';
import { Home } from './src/screens/Home';

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

