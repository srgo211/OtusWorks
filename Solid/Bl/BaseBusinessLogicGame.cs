namespace Solid.Bl;

abstract class BaseBusinessLogicGame
{
    /// <summary>Ввод номера</summary> </summary>
    public abstract BaseBusinessLogicGame InputNumber();

    /// <summary>Проверка номера</summary>
    public abstract BaseBusinessLogicGame CheckNumber();

    /// <summary>Уведомление о результате</summary>
    public abstract Status NotifyResult();


}
