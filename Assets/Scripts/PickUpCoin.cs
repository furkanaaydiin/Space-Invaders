public class PickUpCoin : Pickup
{
    public override void PickMeUp()
    {
        Inventory.CurrentCoins++;
        UIManager.UpdateCoins();
        gameObject.SetActive(false);
    }
}
