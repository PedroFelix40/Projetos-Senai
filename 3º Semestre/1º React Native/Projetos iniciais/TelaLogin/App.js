import { StatusBar } from 'expo-status-bar';
import { LinearGradient } from 'expo-linear-gradient';
import { Image, ImageBackground, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';

export default function App() {
  return (
    <View style={styles.container} >
      <LinearGradient
        style={styles.gradiente}

        start={{ x: 1, y: 0 }}
        end={{ x: 1, y: 0 }}

        colors={['#C3DEC7', '#408DE6']}>



        <View style={styles.box}>
          <LinearGradient
            style={styles.gradienteBox}

            start={{ x: 1, y: 0 }}
            end={{ x: 1, y: 0 }}

            colors={['#C2DB86','#86D8DB']}>
            <Image
              style={styles.image}
              source={require('./src/assets/images/icone-pessoa.png')}
            />


            <View style={styles.login}>
              <Text style={styles.textLogo}>
                LOGIN
              </Text>

              <TextInput
                style={styles.input}
                placeholder='Email'
              />

              <TextInput
                style={styles.input}
                placeholder='Senha'
              />
            </View>

            <TouchableOpacity style={styles.bntLogin}>
              <Text style={styles.text}>
                LOGIN
              </Text>
            </TouchableOpacity>
          </LinearGradient>
        </View>

        <StatusBar style="auto" />
      </LinearGradient>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: "column"
  },
  box: {
    width: '90%',
    height: 550,
    justifyContent: 'space-around',
    borderWidth: 3,
    borderRadius: 15,
    alignItems: 'center',
    marginTop: 40,
  },
  gradienteBox: {
    flex: 1,
    width: '100%',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'space-around',
    borderRadius: 10
  },
  image: {
    width: '45%',
    height: 160,
  },
  login: {
    height: 170,
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  input: {
    width: 300,
    height: 40,

    paddingLeft: 10,

    fontSize: 15,
    borderWidth: 3,
    borderRadius: 5
  },
  text: {
    fontSize: 30,
    color: 'white',
    fontWeight: 500
  },
  textLogo: {
    fontSize: 40,
    color: 'black',
    fontWeight: 800
  },
  bntLogin: {
    width: '90%',
    height: 50,

    borderWidth: 3,
    borderRadius: 5,

    alignItems: 'center',
    backgroundColor: 'black'
  },
  gradiente: {
    flex: 1,
    width: '100%',
    height: '100%',
    alignItems: 'center'
  },
});
