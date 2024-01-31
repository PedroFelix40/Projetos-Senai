import { StyleSheet, Text, View } from "react-native"

const Person = ({ name, age }) => {
    return (
        <View style={styles.container}>
            <Text style={styles.text1}> Nome: {name} </Text>
            <Text style={styles.text2}> Idade: {age} </Text>
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        width: 300,
        backgroundColor: '#c1c1c1',
        padding: 10,
        margin: 10,
        borderRadius: 5,
    },
    text1: {
        color: 'purple',
        fontFamily: 'Poppins_300Light',
        fontSize: 20,
    },
    text2: {
        color: 'purple',
        fontFamily: 'SingleDay_400Regular',
        fontSize: 20,
    }
})

export default Person;